using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.BL.Definitions;
using zeynerp.Entities;
using zeynerp.Entities.Definitions;
using zeynerp.Entities.ViewModels;

namespace zeynerp.Controllers.Definitions
{
    public class CompanyController : Controller
    {
        private CompanyProcess<Company> companyProcess = new CompanyProcess<Company>();

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
    }
}