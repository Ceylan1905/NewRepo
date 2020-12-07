using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class Remainder
    {
        public int Id { get; set; }
        public  float remainder { get; set; }
        public DateTime paymentDate { get; set; }

        public Employee Employee { get; set; }
    }
}
