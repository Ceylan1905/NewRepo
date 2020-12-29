using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.Admin
{
    public class Log
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
        public string UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
