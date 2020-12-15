using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.ViewModels
{
   public class CompanyViewModel
    {
        public Company Companies { get; set; }
        public IEnumerable<CompanyAuthorized> CompanyAuthorizeds { get; set; }
    }
}
