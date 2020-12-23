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
        private SupplierProcess<CompanyGroup> supplierProcess = new SupplierProcess<CompanyGroup>();
        [Authorize]
        [HttpGet]
        public ActionResult SupplierAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SupplierAdd(CompanyGroup companyGroupModel)
        {
            Employee employee = Session["employee"] as Employee;
            int Id = supplierProcess.SupplierAdd(employee, companyGroupModel);
            return RedirectToAction("CompanyDetail", new { Id });
        }

        public ActionResult SupplierList()
        {
            Employee employee = Session["employee"] as Employee;
            List<CompanyGroup> companyGroupModel = supplierProcess.GetCompanyGroupList(employee);
            return View(companyGroupModel);
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