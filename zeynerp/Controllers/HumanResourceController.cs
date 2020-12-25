using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;
using zeynerp.Entities.ViewModels;

namespace zeynerp.Controllers
{
    public class HumanResourceController : Controller
    {
        private HumanResourceManager<Personnel> manager_personnel = new HumanResourceManager<Personnel>();

        [Route("insan-kaynaklari/personel-listesi")]
        public ActionResult PersonnelList(SelectViewModel selectViewModel)
        {
            Employee employee = Session["employee"] as Employee;

            if(employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            List<Personnel> personnels = manager_personnel.GetPersonnels(employee.CompanyName, selectViewModel);
            ViewData["personnels"] = personnels;

            return View();
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        public ActionResult PersonnelAdd()
        {
            return View();
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel personnel, HttpPostedFileBase imageFile)
        {

            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (imageFile != null && (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/jpg" || imageFile.ContentType == "image/png"))
            {
                string filename = $"{employee.CompanyId}_{personnel.Name}_{personnel.Surname}.{imageFile.ContentType.Split('/')[1]}";

                imageFile.SaveAs(Server.MapPath($"~/images/{filename}"));
                personnel.ProfileImage = filename;
                manager_personnel.PersonnelAdd(employee.CompanyName, personnel);
            }
            return View();
        }

        [Route("insan-kaynaklari/personel-detay/{id}")]
        public ActionResult PersonnelDetail(int id)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            BL_Result<Personnel> bL_Result = new BL_Result<Personnel>();
            bL_Result = manager_personnel.GetPersonnel(employee.CompanyName, id);
            return View(bL_Result);
        }

        [Route("insan-kaynaklari/personel-detay/{id}")]
        [HttpPost]
        public ActionResult PersonnelDetail(BL_Result<Personnel> bL_Result, HttpPostedFileBase imageFile)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (imageFile != null)
            {
                string filename = $"{employee.CompanyId}_{bL_Result.Result.Name}_{bL_Result.Result.Surname}.{imageFile.ContentType.Split('/')[1]}";

                imageFile.SaveAs(Server.MapPath($"~/images/{filename}"));
                bL_Result.Result.ProfileImage = filename;
            }

            manager_personnel.PersonnelUpdate(employee.CompanyName, bL_Result);
            return RedirectToAction("PersonnelList");
        }

        [Route("insan-kaynaklari/personel-sil/{id}")]
        public ActionResult PersonnelDelete(int id)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            manager_personnel.PersonnelDelete(employee.CompanyName, id);
            return RedirectToAction("PersonnelList");
        }
    }
}