using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class Company
    {
        public int Id { get; set; }
        //public Staff Staff { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Kind { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Eposta { get; set; }
        public string TaxAdministration { get; set; }
        public string TaxNumber { get; set; }
        public string BillingAddress { get; set; }
        public string CenterOfResponsibility { get; set; }

        public YesNo Confirmation { get; set; }
    }
    public enum YesNo
    {
        Onaysız,
        Onaylı
    }

}
