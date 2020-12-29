using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities;
using zeynerp.Entities.Admin;

namespace zeynerp.Controllers
{
    public class UserOperationsController : Controller
    {
        private UserOperationsManager<Module> manager_useroperations = new UserOperationsManager<Module>();
        public ActionResult Index()
        {
            List<Module> listModule = manager_useroperations.GetModules();
            ViewData["listModule"] = listModule;

            Employee employee = Session["employee"] as Employee;
            List<Employee> listEmployees = manager_useroperations.GetEmployees(employee);
            ViewData["listEmployees"] = listEmployees;

            return View();
        }
    }
}