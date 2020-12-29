using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.Definitions;
using zeynerp.Entities.ViewModels;

namespace zeynerp.BL
{
    public class SupplierProcess<T> where T : class
    {
        private BL_Result<CompanyGroup> result_companyGroup = new BL_Result<CompanyGroup>();
        private SelectViewModel selectViewModel = new SelectViewModel();

        public BL_Result<CompanyGroup> SupplierAdd(string db_name, CompanyGroup companyGroup)
        {
            if (companyGroup != null)
            {
                Repository<CompanyGroup> repo_companyGroup = new Repository<CompanyGroup>(db_name);
                int db = repo_companyGroup.Insert(new CompanyGroup()
                {
                    Name = companyGroup.Name,
                    Confirmation = companyGroup.Confirmation
                });

                if (db > 0)
                {
                    result_companyGroup.Result = repo_companyGroup.Find(x => x.Id == companyGroup.Id);
                }
            }
            return result_companyGroup;
        }
        //public int SupplierAdd(Employee employeeModel, CompanyGroup companyGroupModel)   //Tedarikcilerin kayit olmasi gerceklestiriliyor.
        //{
        //    Repository<CompanyGroup> compGroup = new Repository<CompanyGroup>(employeeModel.CompanyName);
        //    compGroup.Insert(new CompanyGroup()
        //    {
        //        Name = companyGroupModel.Name,
        //        Confirmation = companyGroupModel.Confirmation
        //    });
        //    var list = compGroup.List();
        //    int lastId=list.Max(x => x.Id);
        //    return lastId;
        //}
        //public List<CompanyGroup> GetCompanyGroupList(Employee employeeModel)
        //{

        //    Repository<CompanyGroup> compGroup = new Repository<CompanyGroup>(employeeModel.CompanyName);
        //    var list = compGroup.List();
        //    return list;
        //}

        public List<CompanyGroup> GetCompanyGroupList(string db_name, SelectViewModel selectViewModel)
        {
            Repository<CompanyGroup> repo_companyGroup = new Repository<CompanyGroup>(db_name);

            if (selectViewModel.Confirmation != null)
            {
                if (selectViewModel.Confirmation == "all")
                {
                    List<CompanyGroup> companyGroupsAll = repo_companyGroup.List();
                    return companyGroupsAll;
                }
                
                List<CompanyGroup> companyGroupListFilter = repo_companyGroup.List(x => x.Confirmation == selectViewModel.Confirmation);
                return companyGroupListFilter;
            }

            List<CompanyGroup> companyGroupList = repo_companyGroup.List();
            return companyGroupList;
        }

        public BL_Result<CompanyGroup> GetCompanyGroup(string db_name, int id)  // Tedarikcilerin detay sayfasi icin tedarikci bilgisi cekiliyor.
        {
            Repository<CompanyGroup> repo_companyGroup = new Repository<CompanyGroup>(db_name);
            result_companyGroup.Result = repo_companyGroup.Find(x => x.Id == id);
            return result_companyGroup;
        }

        public BL_Result<CompanyGroup> CompanyGroupUpdate(string db_name, BL_Result<CompanyGroup> updatedCompanyGroup)   //tedarikci guncelleniyor.
        {
            Repository<CompanyGroup> repo_companyGroup = new Repository<CompanyGroup>(db_name);
            CompanyGroup companyGroup = repo_companyGroup.Find(x => x.Id == updatedCompanyGroup.Result.Id);
            if (companyGroup != null)
            {
                companyGroup.Name = updatedCompanyGroup.Result.Name;
                companyGroup.Confirmation = updatedCompanyGroup.Result.Confirmation;
            }
            repo_companyGroup.Update(companyGroup);
            return result_companyGroup;
        }

    }
}
