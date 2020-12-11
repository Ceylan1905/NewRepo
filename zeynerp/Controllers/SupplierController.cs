using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities;

namespace zeynerp.Controllers
{
    public class SupplierController : Controller
    {
        private Manager<User> manager_user = new Manager<User>();
        private Manager<Employee> manager_employee = new Manager<Employee>();
        private SupplierProcess<CompanyGroup> companyProcess = new <CompanyGroup>();
        [Authorize]
        [HttpGet]
        //public ActionResult CompanyAdd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CompanyAdd(Company companyModel)
        //{
        //    Employee employee = Session["employee"] as Employee;
        //    int Id = companyProcess.CompanyAdd(employee, companyModel);
        //    return RedirectToAction("CompanyDetail", new { Id });
        //}

        public ActionResult SupplierList()
        {
            
            return View( );
        }


        //public ActionResult CompanyDetail(int id)
        //{
        //    Employee employee = Session["employee"] as Employee;
        //    Company comp = companyProcess.GetCompany(employee, id);
        //    return View(comp);
        //}

        //[HttpPost]
        //public ActionResult CompanyDetail(Company companyModel)
        //{
        //    Employee employee = Session["employee"] as Employee;
        //    int deneme = companyProcess.CompanyUpdate(employee, companyModel);
        //    return View(companyModel);
        //}
    }
}