using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class CompanyGroup:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public YesNo Confirmation { get; set; }
    }
}
