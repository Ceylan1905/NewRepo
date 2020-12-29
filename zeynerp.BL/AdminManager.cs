using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
<<<<<<< HEAD
using zeynerp.Entities;
=======
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
using zeynerp.Entities.Admin;

namespace zeynerp.BL
{
    public class AdminManager<T> where T : class
    {
        private BL_Result<Category> result_category = new BL_Result<Category>();
<<<<<<< HEAD
        private BL_Result<Module> result_module = new BL_Result<Module>();

        private UserRepository<Category> repo_category = new UserRepository<Category>();
        private UserRepository<Module> repo_module = new UserRepository<Module>();
        private UserRepository<Log> repo_log = new UserRepository<Log>();

=======
        private UserRepository<Category> repo_category = new UserRepository<Category>();
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
        public List<Category> GetCategories()
        {
            List<Category> listCategory = repo_category.List();
            return listCategory;
        }

        public BL_Result<Category> CategoryAdd(Category category)
        {
            result_category.Result = repo_category.Find(x => x.CategoryName == category.CategoryName);

            if (result_category.Result == null)
            {
                int db = repo_category.Insert(new Category()
                {
                    CategoryName = category.CategoryName,
                    Order = category.Order,
                    Status = category.Status
                });

                if (db > 0)
                {
                    result_category.Result = repo_category.Find(x => x.CategoryName == category.CategoryName);
                }
            }
            else
            {
                result_category.addError(Common.Messages.ErrorMessages.RegisteredCategory, "Kategori ismi mevcut");
            }
            return result_category;
        }
<<<<<<< HEAD

        public BL_Result<Module> GetModule(int id)
        {
            result_module.Result = repo_module.Find(x => x.Id == id);
            return result_module;
        }

        public List<Module> GetModules(int id)
        {
            List<Module> listModule = repo_module.List(x => x.CategoryId == id);
            return listModule;
        }

        public BL_Result<Module> ModuleAdd(int id, Module module)
        {
            result_module.Result = repo_module.Find(x => x.ModuleName == module.ModuleName);
            if (result_module.Result == null)
            {
                int db = repo_module.Insert(new Module()
                {
                    ModuleName = module.ModuleName,
                    Status = module.Status,
                    Order = module.Order,
                    Price = module.Price,
                    CurrencyUnit = module.CurrencyUnit,
                    Comment = module.Comment,
                    CategoryId = id
                });

                if (db > 0)
                {
                    result_module.Result = repo_module.Find(x => x.ModuleName == module.ModuleName);
                }
            }
            else
            {
                result_module.addError(Common.Messages.ErrorMessages.RegisteredModule, "Modül ismi mevcut");
            }
            return result_module;
        }

        public BL_Result<Module> ModuleUpdate(BL_Result<Module> module, User owner)
        {
            Module update_module  = repo_module.Find(x => x.CategoryId == module.Result.CategoryId && x.Id == module.Result.Id);

            if (update_module != null)
            {
                repo_log.Insert(new Log()
                {
                    ModuleId = update_module.Id,
                    CategoryId = update_module.CategoryId,
                    Owner = owner.Name + " " + owner.Surname,
                    Price = update_module.Price + " " + update_module.CurrencyUnit,
                    UpdatedDate = String.Format("{0:dd/MM/yyyy}", DateTime.Now),
                    Comment = module.Result.Comment
                });

                update_module.ModuleName = module.Result.ModuleName;
                update_module.Order = module.Result.Order;
                update_module.Status = module.Result.Status;
                update_module.Price = module.Result.Price;
                update_module.CurrencyUnit = module.Result.CurrencyUnit;
                update_module.Comment = null;

                repo_module.Update(update_module);
                result_module.Result = repo_module.Find(x => x.ModuleName == module.Result.ModuleName);
            }
            else
            {
                result_module.addError(Common.Messages.ErrorMessages.RegisteredModule, "Modül ismi mevcut");
            }
            return result_module;
        }

        public List<Log> GetModuleLog(int id)
        {
            List<Log> listLog = repo_log.List(x => x.ModuleId == id);
            return listLog;
        }
=======
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
    }
}
