using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities;
using zeynerp.Entities.Definitions;
using zeynerp.Entities.ViewModels;

namespace zeynerp.Controllers
{
    public class SupplierController : Controller
    {
        private SupplierProcess<CompanyGroup> supplierProcess = new SupplierProcess<CompanyGroup>();

        [Route("tanimlamalar/tedarikci-ekle")]
        public ActionResult SupplierAdd()
        {
            return View();
        }

        [Route("tanimlamalar/tedarikci-ekle")]
        [HttpPost]
        public ActionResult SupplierAdd(CompanyGroup companyGroup)
        {

            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            supplierProcess.SupplierAdd(employee.CompanyName, companyGroup);
            return View();
        }

        //[HttpPost]
        //public ActionResult SupplierAdd(CompanyGroup companyGroupModel)
        //{
        //    Employee employee = Session["employee"] as Employee;
        //    int Id = supplierProcess.SupplierAdd(employee, companyGroupModel);
        //    return RedirectToAction("CompanyDetail", new { Id });
        //}

        [Route("tanimlamalar/tedarikci-listesi")]
        public ActionResult SupplierList()
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            List<CompanyGroup> companyGroups = supplierProcess.GetCompanyGroupList(employee.CompanyName, selectViewModel);
            ViewData["compGroup"] = companyGroups;

            return View();
        }

        [Route("tanimlamalar/tedarikci-detay/{id}")]
        public ActionResult SupplierDetail(int id)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            BL_Result<CompanyGroup> bL_Result = new BL_Result<CompanyGroup>();
            bL_Result = supplierProcess.GetCompanyGroup(employee.CompanyName, id);
            return View(bL_Result);
        }


        [Route("tanimlamalar/tedarikci-detay/{id}")]
        [HttpPost]
        public ActionResult SupplierDetail(BL_Result<CompanyGroup> bL_Result)
        {
            Employee employee = Session["employee"] as Employee;

            if (employee == null)
            {
                return RedirectToAction("SignIn", "Home");
            }
            supplierProcess.CompanyGroupUpdate(employee.CompanyName, bL_Result);
            return RedirectToAction("SupplierList");
        }
    }
}