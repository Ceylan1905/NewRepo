using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
   public class CompanyAuthorized
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }

        public string Phone { get; set; }
        public string MobilePhone  { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public IsActive IsActive { get; set; }
        public int CompanyId { get; set; }
        public Company Companies { get; set; }
    }
    public enum IsActive
    {
        Pasif,
        Aktif
    }
}


