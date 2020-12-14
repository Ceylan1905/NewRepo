using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;

namespace zeynerp.BL
{
    public class SupplierProcess<T> where T : class
    {
        private BL_Result<Employee> result_employee = new BL_Result<Employee>();
        //private BL_Result<Company> result_company = new BL_Result<Company>();
        private BL_Result<CompanyGroup> result_company = new BL_Result<CompanyGroup>();

        public int CompanyAdd(Employee employeeModel, CompanyGroup companyGroupModel)
        {
            Repository<CompanyGroup> compGroup = new Repository<CompanyGroup>(employeeModel.CompanyName);
            compGroup.Insert(new CompanyGroup()
            {
                Name = companyGroupModel.Name,
                Confirmation = companyGroupModel.Confirmation
            });
            int sonKayitId = compGroup.deneme();   //devam
            return sonKayitId;
        }
        public List<CompanyGroup> GetCompanyGroupList(Employee employeeModel)
        {
            Repository<CompanyGroup> compGroup = new Repository<CompanyGroup>(employeeModel.CompanyName);
            var list = compGroup.List();
            return list;
        }
    }
}
