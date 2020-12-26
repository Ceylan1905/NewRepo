using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities.Admin;

namespace zeynerp.BL
{
    public class AdminManager<T> where T : class
    {
        private BL_Result<Category> result_category = new BL_Result<Category>();
        private UserRepository<Category> repo_category = new UserRepository<Category>();
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
    }
}
