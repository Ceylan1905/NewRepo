using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.ViewModels
{
    public class EmployeeModuleViewModel
    {
        public IEnumerable<Module> Modules { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
