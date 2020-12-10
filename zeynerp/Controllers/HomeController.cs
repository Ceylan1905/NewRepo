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
        public ActionResult CompanyAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompanyAdd(Company companyModel)
        {
            Employee employee = Session["employee"] as Employee;
            BL_Result<Company> company_result = companyProcess.CompanyAdd(employee, companyModel);

            return View();
        }

        public ActionResult CompanyList()
        {
            Employee employee = Session["employee"] as Employee;
            List<Company> companies = companyProcess.GetCompany(employee);
            return View(companies);
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