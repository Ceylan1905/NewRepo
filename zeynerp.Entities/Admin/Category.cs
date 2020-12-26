using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.Admin
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori isim alanı gereklidir.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Durum alanı gereklidir.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Sıra alanı gereklidir.")]
        public int Order { get; set; }
    }
}
