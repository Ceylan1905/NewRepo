using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using zeynerp.BL;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;
using zeynerp.Entities.ViewModels;

namespace zeynerp.Controllers
{ 
    public class HomeController : Controller
    {
        private Manager<User> manager_user = new Manager<User>();
        private Manager<Employee> manager_employee = new Manager<Employee>();
        private CompanyProcess<Company> companyProcess = new CompanyProcess<Company>();
        private PaymentManager payment = new PaymentManager();
        public ActionResult Index()
        {
            return View();
        }

        [Route("uyelik")]
        public ActionResult SignUp()
        {
            return View();
        }

        [Route("uyelik")]
        [HttpPost]
        public ActionResult SignUp(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                BL_Result<User> bl_Result = manager_user.Register(registerViewModel);
                if(bl_Result.Messages.Count > 0)
                {
                    bl_Result.Messages.ForEach(x => ModelState.AddModelError("", x));
                }
            }
            return View();
        }

        [HttpPost]

        public JsonResult ChangePassword(string formData)
        {
            
                var employee = Session["employee"] as Employee;
                if(employee!=null)
                {
                if (formData != "")
                {
                    manager_employee.ManagePassword(employee, formData);
                    return Json(new { status=true, message = "Şifreniz değiştirildi!",url="/panel" });
                   
                }
             
            }
            return Json(new { status = false, message = "Hata var!" });
        }
        public ActionResult Activation(Guid id)
        {
            ViewBag.Message = "Invalid Activation code.";
            if (id != null)
            {
                manager_employee.Activation(id);
                ViewBag.Message = "Activation successful.";
                return View("SignIn");
            }
            return View();
        }

      
        [Route("giris")]
        public ActionResult SignIn()
        {
            return View();
        }

       
        [Route("giris")]
        [HttpPost]
      
        public ActionResult SignIn(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                BL_Result<Employee> bl_Result = manager_employee.Login(loginViewModel);

                if(bl_Result.Messages.Count > 0)
                {
                    bl_Result.Messages.ForEach(x => ModelState.AddModelError("", x));
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(bl_Result.Result.Name, false);
                    Session["employee"] = bl_Result.Result;
                    var remainder = payment.GetRemainder(bl_Result.Result);
                    Session["remainder"] = remainder;
                    Session["password"] = loginViewModel.Password;
                    return RedirectToAction("Dashboard");
                }
            }
            return View();
        }

        [Route("panel")]
        [Authorize]
        public ActionResult Dashboard()
        {
            Employee employee = Session["employee"] as Employee;
            if (employee != null)
            {
                return View();
            }
            return RedirectToAction("SignIn");
        }

        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Profile(HttpPostedFileBase imageFile)
        {
            var profileInfos = Session["employee"] as Employee;
            if (ModelState.IsValid)
            {
                if (imageFile != null && (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/jpg" || imageFile.ContentType == "image/png"))
                {
                    string filename = $"{profileInfos.CompanyId}_{profileInfos.Id}.{imageFile.ContentType.Split('/')[1]}";

                    imageFile.SaveAs(Server.MapPath($"~/images/{filename}"));
                    profileInfos.ProfileImage = filename;
                    BL_Result<Employee> bl_Result = manager_employee.EditProfile(profileInfos);
                }
            }

            return View();
        }
        [Authorize]
        public ActionResult Authorization()
        {
            Employee employee = Session["employee"] as Employee;
            if(employee!=null)
            {
                List<Employee> employees = manager_employee.GetCustomer(employee);

                var remainder = payment.GetRemainder(employee);
                ViewBag.Remainder = remainder;
                return View(employees);
            }
           return  RedirectToAction("SignIn");
        }

        [Authorize]
        [HttpGet]
        public ActionResult CompanyAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompanyAdd(Company companyModel)
        {
            Employee employee = Session["employee"] as Employee;
            int Id = companyProcess.CompanyAdd(employee, companyModel);
            return RedirectToAction("CompanyDetail", new { Id });
        }

        public ActionResult CompanyList()
        {
            Employee employee = Session["employee"] as Employee;
            List<Company> companies = companyProcess.GetCompanyList(employee);
            return View(companies);
        }


        public ActionResult CompanyDetail(int id)
        {
            Employee employee = Session["employee"] as Employee;
            Company comp = companyProcess.GetCompany(employee, id);
            return View(comp);
        }

        [HttpPost]
        public ActionResult CompanyDetail(Company companyModel)
        {
            Employee employee = Session["employee"] as Employee;
            Company comp = companyProcess.CompanyUpdate(employee, companyModel);
            return View(comp);
        }

        [Route("insan-kaynaklari/personel-listesi")]
        [Authorize]
        public ActionResult PersonnelList()
        {
            Employee employee = Session["employee"] as Employee;
            List<Employee> employees = manager_employee.GetCustomer(employee);
            return View(employees);
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        public ActionResult PersonnelAdd()
        {
            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem { Text = "Adana", Value = "Adana" });
            city.Add(new SelectListItem { Text = "Adıyaman", Value = "Adıyaman" });
            city.Add(new SelectListItem { Text = "Afyon", Value = "Afyon" });
            city.Add(new SelectListItem { Text = "Ağrı", Value = "Ağrı" });
            city.Add(new SelectListItem { Text = "Aksaray", Value = "Aksaray" });
            city.Add(new SelectListItem { Text = "Amasya", Value = "Amasya" });
            city.Add(new SelectListItem { Text = "Ankara", Value = "Ankara" });
            city.Add(new SelectListItem { Text = "Antalya", Value = "Antalya" });
            city.Add(new SelectListItem { Text = "Ardahan", Value = "Ardahan" });
            city.Add(new SelectListItem { Text = "Artvin", Value = "Artvin" });
            city.Add(new SelectListItem { Text = "Aydın", Value = "Aydın" });
            city.Add(new SelectListItem { Text = "Balıkesir", Value = "Balıkesir" });
            city.Add(new SelectListItem { Text = "Bartın", Value = "Bartın" });
            city.Add(new SelectListItem { Text = "Batman", Value = "Batman" });
            city.Add(new SelectListItem { Text = "Bayburt", Value = "Bayburt" });
            city.Add(new SelectListItem { Text = "Bilecik", Value = "Bilecik" });
            city.Add(new SelectListItem { Text = "Bingöl", Value = "Bingöl" });
            city.Add(new SelectListItem { Text = "Bitlis", Value = "Bitlis" });
            city.Add(new SelectListItem { Text = "Bolu", Value = "Bolu" });
            city.Add(new SelectListItem { Text = "Burdur", Value = "Burdur" });
            city.Add(new SelectListItem { Text = "Bursa", Value = "Bursa" });
            city.Add(new SelectListItem { Text = "Çanakkale", Value = "Çanakkale" });
            city.Add(new SelectListItem { Text = "Çankırı", Value = "Çankırı" });
            city.Add(new SelectListItem { Text = "Çorum", Value = "Çorum" });
            city.Add(new SelectListItem { Text = "Denizli", Value = "Denizli" });
            city.Add(new SelectListItem { Text = "Diyarbakır", Value = "Diyarbakır" });
            city.Add(new SelectListItem { Text = "Düzce", Value = "Düzce" });
            city.Add(new SelectListItem { Text = "Edirne", Value = "Edirne" });
            city.Add(new SelectListItem { Text = "Elazığ", Value = "Elazığ" });
            city.Add(new SelectListItem { Text = "Erzincan", Value = "Erzincan" });
            city.Add(new SelectListItem { Text = "Erzurum", Value = "Erzurum" });
            city.Add(new SelectListItem { Text = "Eskişehir", Value = "Eskişehir" });
            city.Add(new SelectListItem { Text = "Gaziantep", Value = "Gaziantep" });
            city.Add(new SelectListItem { Text = "Giresun", Value = "Giresun" });
            city.Add(new SelectListItem { Text = "Gümüşhane", Value = "Gümüşhane" });
            city.Add(new SelectListItem { Text = "Hakkari", Value = "Hakkari" });
            city.Add(new SelectListItem { Text = "Hatay", Value = "Hatay" });
            city.Add(new SelectListItem { Text = "Iğdır", Value = "Iğdır" });
            city.Add(new SelectListItem { Text = "Isparta", Value = "Isparta" });
            city.Add(new SelectListItem { Text = "İstanbul", Value = "İstanbul" });
            city.Add(new SelectListItem { Text = "İzmir", Value = "İzmir" });
            city.Add(new SelectListItem { Text = "Kahramanmaraş", Value = "Kahramanmaraş" });
            city.Add(new SelectListItem { Text = "Karabük", Value = "Karabük" });
            city.Add(new SelectListItem { Text = "Karaman", Value = "Karaman" });
            city.Add(new SelectListItem { Text = "Kars", Value = "Kars" });
            city.Add(new SelectListItem { Text = "Kastamonu", Value = "Kastamonu" });
            city.Add(new SelectListItem { Text = "Kayseri", Value = "Kayseri" });
            city.Add(new SelectListItem { Text = "Kırıkkale", Value = "Kırıkkale" });
            city.Add(new SelectListItem { Text = "Kırklareli", Value = "Kırklareli" });
            city.Add(new SelectListItem { Text = "Kırşehir", Value = "Kırşehir" });
            city.Add(new SelectListItem { Text = "Kilis", Value = "Kilis" });
            city.Add(new SelectListItem { Text = "Kocaeli", Value = "Kocaeli" });
            city.Add(new SelectListItem { Text = "Konya", Value = "Konya" });
            city.Add(new SelectListItem { Text = "Kütahya", Value = "Kütahya" });
            city.Add(new SelectListItem { Text = "Malatya", Value = "Malatya" });
            city.Add(new SelectListItem { Text = "Manisa", Value = "Manisa" });
            city.Add(new SelectListItem { Text = "Mardin", Value = "Mardin" });
            city.Add(new SelectListItem { Text = "Mersin", Value = "Mersin" });
            city.Add(new SelectListItem { Text = "Muğla", Value = "Muğla" });
            city.Add(new SelectListItem { Text = "Muş", Value = "Muş" });
            city.Add(new SelectListItem { Text = "Nevşehir", Value = "Nevşehir" });
            city.Add(new SelectListItem { Text = "Niğde", Value = "Niğde" });
            city.Add(new SelectListItem { Text = "Ordu", Value = "Ordu" });
            city.Add(new SelectListItem { Text = "Osmaniye", Value = "Osmaniye" });
            city.Add(new SelectListItem { Text = "Rize", Value = "Rize" });
            city.Add(new SelectListItem { Text = "Sakarya", Value = "Sakarya" });
            city.Add(new SelectListItem { Text = "Samsun", Value = "Samsun" });
            city.Add(new SelectListItem { Text = "Siirt", Value = "Siirt" });
            city.Add(new SelectListItem { Text = "Sinop", Value = "Sinop" });
            city.Add(new SelectListItem { Text = "Sivas", Value = "Sivas" });
            city.Add(new SelectListItem { Text = "Şanlıurfa", Value = "Şanlıurfa" });
            city.Add(new SelectListItem { Text = "Şırnak", Value = "Şırnak" });
            city.Add(new SelectListItem { Text = "Tekirdağ", Value = "Tekirdağ" });
            city.Add(new SelectListItem { Text = "Tokat", Value = "Tokat" });
            city.Add(new SelectListItem { Text = "Trabzon", Value = "Trabzon" });
            city.Add(new SelectListItem { Text = "Tunceli", Value = "Tunceli" });
            city.Add(new SelectListItem { Text = "Uşak", Value = "Uşak" });
            city.Add(new SelectListItem { Text = "Van", Value = "Van" });
            city.Add(new SelectListItem { Text = "Yalova", Value = "Yalova" });
            city.Add(new SelectListItem { Text = "Yozgat", Value = "Yozgat" });
            city.Add(new SelectListItem { Text = "Zonguldak", Value = "Zonguldak" });
            ViewBag.Cities = city;

            List<SelectListItem> militaryStatus = new List<SelectListItem>();
            militaryStatus.Add(new SelectListItem { Text = "Yapılmadı", Value = "Yapılmadı" });
            militaryStatus.Add(new SelectListItem { Text = "Yapıldı", Value = "Yapıldı" });
            militaryStatus.Add(new SelectListItem { Text = "Tecilli", Value = "Tecilli" });
            militaryStatus.Add(new SelectListItem { Text = "Muaf", Value = "Muaf" });
            ViewBag.MilitaryStatus = militaryStatus;

            List<SelectListItem> maritalStatus = new List<SelectListItem>();
            maritalStatus.Add(new SelectListItem { Text = "Bekar", Value = "Bekar" });
            maritalStatus.Add(new SelectListItem { Text = "Evli", Value = "Evli" });
            ViewBag.MaritalStatus = maritalStatus;

            List<SelectListItem> availableOrUnavailable = new List<SelectListItem>();
            availableOrUnavailable.Add(new SelectListItem { Text = "Yok", Value = "Yok" });
            availableOrUnavailable.Add(new SelectListItem { Text = "Var", Value = "Var" });
            ViewBag.AvailableOrUnavailable = availableOrUnavailable;

            List<SelectListItem> yesOrNo = new List<SelectListItem>();
            yesOrNo.Add(new SelectListItem { Text = "Hayır", Value = "0" });
            yesOrNo.Add(new SelectListItem { Text = "Evet", Value = "1" });
            ViewBag.YesOrNo = yesOrNo;

            List<SelectListItem> firma = new List<SelectListItem>();
            firma.Add(new SelectListItem { Text = "Kadro", Value = "0" });
            ViewBag.Firma = firma;

            List<SelectListItem> sorumlulukmerkezi = new List<SelectListItem>();
            sorumlulukmerkezi.Add(new SelectListItem { Text = "S-Mak", Value = "0" });
            ViewBag.Sorumlulukmerkezi = sorumlulukmerkezi;

            List<SelectListItem> amir = new List<SelectListItem>();
            amir.Add(new SelectListItem { Text = "Selim SELİMOĞLU", Value = "0" });
            ViewBag.Amir = amir;

            List<SelectListItem> pozisyon = new List<SelectListItem>();
            pozisyon.Add(new SelectListItem { Text = "Yazılım", Value = "0" });
            ViewBag.Pozisyon = pozisyon;
            return View();
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel personnel)
        {
            return View();
        }

    
        public ActionResult guncelleBakiye(float bakiye)
        {
            Employee employee = Session["employee"] as Employee;
            int updateResult = payment.UpdateRemainder(employee, bakiye);
            if(updateResult>0)
            {

                Session["remainder"] = bakiye;

                return RedirectToAction("Authorization");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return View("SignIn");
        }
    }
}