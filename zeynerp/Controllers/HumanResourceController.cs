using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;

namespace zeynerp.Controllers
{
    public class HumanResourceController : Controller
    {
        private Manager<Employee> manager_employee = new Manager<Employee>();
        private HumanResourceManager<Personnel> manager_personnel = new HumanResourceManager<Personnel>();

        [Route("insan-kaynaklari/personel-listesi")]
        [Authorize]
        public ActionResult PersonnelList()
        {
            Employee employee = Session["employee"] as Employee;
            List<Personnel> personnels = manager_personnel.GetPersonnels(employee.CompanyName);
            return View(personnels);
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        public ActionResult PersonnelAdd(int? id)
        {
            if(id != null)
            {
                Employee employee = Session["employee"] as Employee;
                Personnel personnel = manager_personnel.GetPersonnel(employee.CompanyName, id.Value);
                return View(personnel);
            }

            return View();
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel personnel)
        {
            if (ModelState.IsValid) {
                Employee employee = Session["employee"] as Employee;
                manager_personnel.PersonnelAdd(employee.CompanyName, personnel);

                return RedirectToAction("PersonnelList");
            }
            return View();
        }
    }
}