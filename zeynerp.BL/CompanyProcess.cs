using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;

namespace zeynerp.BL
{
    public class CompanyProcess<T> where T : class
    {
        private BL_Result<Employee> result_employee = new BL_Result<Employee>();
        private BL_Result<Company> result_company = new BL_Result<Company>();
        public int CompanyAdd(Employee employeeModel, Company companyModel)
        {
            Repository<Company> comp = new Repository<Company>(employeeModel.CompanyName);
            comp.Insert(new Company()
            {
                Name = companyModel.Name,
                ShortName = companyModel.ShortName,
                Kind = companyModel.Kind,
                Phone = companyModel.Phone,
                Fax = companyModel.Fax,
                Eposta = companyModel.Eposta,
                TaxAdministration = companyModel.TaxAdministration,
                TaxNumber = companyModel.TaxNumber,
                BillingAddress = companyModel.BillingAddress,
                //CenterOfResponsibility = companyModel.CenterOfResponsibility,
                Confirmation = companyModel.Confirmation
            }) ;
            int sonKayitId = comp.deneme();
            return sonKayitId;
        }

        public List<Company> GetCompanyList(Employee employeeModel)
        {
            Repository<Company> companyList = new Repository<Company>(employeeModel.CompanyName);
            var list = companyList.List();
            return list;
        }


        public Company GetCompany(Employee employeeModel, int id)
        {
            Repository<Company> comp = new Repository<Company>(employeeModel.CompanyName);
            Company company = comp.Find(x => x.Id == id );
            return company;
        }
        
        public int CompanyUpdate(Employee employeeModel, Company companyModel)
        {
            Repository<Company> comp = new Repository<Company>(employeeModel.CompanyName);
            int updateResult=comp.UpdateCompany(companyModel);
            return updateResult;
        }
    }
}
