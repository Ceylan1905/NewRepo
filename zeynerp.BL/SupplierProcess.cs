using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.BL
{
    public class SupplierProcess<T> where T : class
    {
        private BL_Result<Employee> result_employee = new BL_Result<Employee>();
        private BL_Result<CompanyGroup> result_company = new BL_Result<CompanyGroup>();

    }
}
