using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.Admin
{
    public class Module
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Modül isim alanı gereklidir.")]
        public string ModuleName { get; set; }
        [Required(ErrorMessage = "Sıra alanı gereklidir.")]
        public int Order { get; set; }
        [Required(ErrorMessage = "Durum alanı gereklidir.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Fiyat alanı gereklidir.")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Fiyat birim alanı gereklidir.")]
        public string CurrencyUnit { get; set; }
        public string Comment { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
