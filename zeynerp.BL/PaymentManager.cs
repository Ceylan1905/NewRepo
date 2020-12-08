using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;

namespace zeynerp.BL
{
   public class PaymentManager
    {
        private BL_Result<Employee> result_employee = new BL_Result<Employee>();
        public float? GetRemainder(Employee employee)
        {
            if (employee.IsAdmin == true)
            {
                Repository<Remainder> repo = new Repository<Remainder>(employee.CompanyName);

                if(repo.List().Count > 0)
                {
                    float? remainder = repo.GetRemainder();
                    return remainder;
                }
               
              
              
            }
            return null;
        }
    }
}
