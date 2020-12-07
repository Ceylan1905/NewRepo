using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string Repassword { get; set; }
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string ProfileImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public Guid Guid { get; set; }
    }
}
