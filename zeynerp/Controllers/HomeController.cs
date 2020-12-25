using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using zeynerp.BL;
using zeynerp.BL.Result;
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
                    return View();
                }
                return RedirectToAction("SignIn");
            }
            return View();
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
            Session["employee"] = null;
            return View();
        }

       
        [Route("giris")]
        [HttpPost]      
        public ActionResult SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                LoginResult loginResult = new LoginResult();
                loginResult = manager_user.Login(loginViewModel);

                if (loginResult.Messages.Count > 0)
                {
                    loginResult.Messages.ForEach(x => ModelState.AddModelError("", x));
                    return View();
                }

                if(loginResult.BL_ResultUser.Result != null)
                {
                    Session["employee"] = loginResult.BL_ResultUser.Result;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    Session["employee"] = loginResult.BL_ResultEmployee.Result;

                    /* Düzenlenecek (Auth ve Birden fazla session kullanımı engellenecek) */
                    var remainder = payment.GetRemainder(loginResult.BL_ResultEmployee.Result);
                    //FormsAuthentication.SetAuthCookie(bl_Result.Result.Name, false);
                    Session["remainder"] = remainder;
                    Session["password"] = loginViewModel.Password;

                    return RedirectToAction("Dashboard");
                }
            }
            return View();
        }

        [Route("panel")]
        //[Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]

        public JsonResult ChangePassword(string formData)
        {

            var employee = Session["employee"] as Employee;
            if (employee != null)
            {
                if (formData != "")
                {
                    manager_employee.ManagePassword(employee, formData);
                    return Json(new { status = true, message = "Şifreniz değiştirildi!", url = "/panel" });

                }

            }
            return Json(new { status = false, message = "Hata var!" });
        }

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
      
        public ActionResult Authorization()
        {
            Employee employee = Session["employee"] as Employee;
            if (employee != null)
            {
                List<Employee> employees = manager_employee.GetCustomer(employee);

                return View(employees);
            }
            return RedirectToAction("SignIn");
        }

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

            if (employee == null)
            {
                return RedirectToAction("SignIn");
            }

            List<Company> companies = companyProcess.GetCompanyList(employee);
            return View(companies);
        }


        public ActionResult CompanyDetail(int id)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn");
            }

            CompanyViewModel companyviewModel = new CompanyViewModel();
            companyviewModel.Companies = companyProcess.GetCompany(employee, id);
            companyviewModel.CompanyAuthorizeds = companyProcess.GetCompanyAuthorizedList(employee, id);
            List<CompanyAuthorized> authorized = companyProcess.GetCompanyAuthorizedList(employee, id);
            return View(companyviewModel);
        }

        [HttpPost]
        public ActionResult CompanyDetail(Company companyModel)
        {
            Employee employee = Session["employee"] as Employee;
            Company comp = companyProcess.CompanyUpdate(employee, companyModel);
            return View(comp);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return View("SignIn");
        }
    }
}