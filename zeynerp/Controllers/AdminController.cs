using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
<<<<<<< HEAD
using zeynerp.Entities;
=======
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
using zeynerp.Entities.Admin;

namespace zeynerp.Controllers
{
    public class AdminController : Controller
    {
        private AdminManager<Category> adminManager = new AdminManager<Category>();
<<<<<<< HEAD

        public ActionResult Dashboard(int? id)
=======
        public ActionResult Module()
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
        {
            //if (ModelState.IsValid)
            //{
            //    BL_Result<Category> bl_category = adminManager.CategoryAdd(category);
            //    if (bl_category.Messages.Count > 0)
            //    {
            //        bl_category.Messages.ForEach(x => ModelState.AddModelError("", x));
            //        return View(category);
            //    }
            //}
            List<Category> listCategory = adminManager.GetCategories();
            ViewData["categories"] = listCategory;
            return View();
        }

<<<<<<< HEAD
        public ActionResult Category()
        {
            List<Category> listCategory = adminManager.GetCategories();
            ViewData["categories"] = listCategory;

            return View();
        }

        [HttpPost]
        public ActionResult Category(Category category)
=======
        [HttpPost]
        public ActionResult Module(Category category)
        {
            BL_Result<Category> bl_category = adminManager.CategoryAdd(category);
            List<Category> listCategory = adminManager.GetCategories();
            ViewData["categories"] = listCategory;

            if (bl_category.Messages.Count > 0)
            {
                bl_category.Messages.ForEach(x => ModelState.AddModelError("", x));
                return View(category);
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Module(Category category)
        //{
        //    if (category != null)
        //    {
        //        BL_Result<Category> bl_category = adminManager.CategoryAdd(category);
        //        if (bl_category.Messages.Count > 0)
        //        {
        //            bl_category.Messages.ForEach(x => ModelState.AddModelError("", x));
        //        }
        //    }

        //    return View(category);
        //}

        public ActionResult ModuleDetail()
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
        {
            if (ModelState.IsValid)
            {
                BL_Result<Category> bl_category = adminManager.CategoryAdd(category);
                if (bl_category.Messages.Count > 0)
                {
                    bl_category.Messages.ForEach(x => ModelState.AddModelError("", x));
                }

                List<Category> listCategory = adminManager.GetCategories();
                ViewData["categories"] = listCategory;
            }           
            return View();
        }

        public ActionResult CategoryDetail(int id)
        {
            List<Module> listModule = adminManager.GetModules(id);
            ViewData["modules"] = listModule;
            return View();
        }

        [HttpPost]
        public ActionResult CategoryDetail(int id, Module module)
        {
            if (ModelState.IsValid)
            {
                BL_Result<Module> bl_module = adminManager.ModuleAdd(id, module);
                if (bl_module.Messages.Count > 0)
                {
                    bl_module.Messages.ForEach(x => ModelState.AddModelError("", x));
                }
                List<Module> listModule = adminManager.GetModules(id);
                ViewData["modules"] = listModule;
            }
            return View();
        }

        public ActionResult ModuleDetail(int id)
        {
            BL_Result<Module> bl_module = new BL_Result<Module>();
            bl_module = adminManager.GetModule(id);
            return View(bl_module);
        }

        [HttpPost]
        public ActionResult ModuleDetail(BL_Result<Module> module)
        {
            BL_Result<Module> bl_module = new BL_Result<Module>();
            User owner = Session["employee"] as User;
            bl_module = adminManager.ModuleUpdate(module, owner);

            if (bl_module.Messages.Count > 0)
            {
                bl_module.Messages.ForEach(x => ModelState.AddModelError("", x));
                return RedirectToAction("ModuleDetail");
            }
            return RedirectToAction("CategoryDetail", new { id = bl_module.Result.CategoryId });
        }

        public ActionResult ModuleLog(int id)
        {
            List<Log> logList = adminManager.GetModuleLog(id);
            ViewData["logs"] = logList;

            BL_Result<Module> bl_module = new BL_Result<Module>();
            bl_module = adminManager.GetModule(id);
            return View(bl_module);
        }
    }
}