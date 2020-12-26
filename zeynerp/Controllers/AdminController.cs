using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Entities.Admin;

namespace zeynerp.Controllers
{
    public class AdminController : Controller
    {
        private AdminManager<Category> adminManager = new AdminManager<Category>();
        public ActionResult Module()
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
        {
            return View();
        }
        public ActionResult ModuleLog()
        {
            return View();
        }
    }
}