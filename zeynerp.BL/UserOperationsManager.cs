using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.Admin;

namespace zeynerp.BL
{
    public class UserOperationsManager<T> where T : class
    {
        private UserRepository<Module> repo_user = new UserRepository<Module>();
        
        public List<Module> GetModules()
        {
            List<Module> listModule = repo_user.List();
            return listModule;
        }

        public List<Employee> GetEmployees(Employee employee)
        {
            Repository<Employee> repo_employee = new Repository<Employee>(employee.CompanyName);
            List<Employee> listEmployee = repo_employee.List();
            return listEmployee;
        }
    }
}
