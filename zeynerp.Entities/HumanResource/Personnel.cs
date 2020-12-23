using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.HumanResource
{
    public class Personnel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim alanı gereklidir.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Doğum yeri alanı gereklidir.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Doğum tarihi alanı gereklidir.")]
        public string Birthday { get; set; }
        [Required(ErrorMessage = "Tc numarası alanı gereklidir.")]
        public string Tc_No { get; set; }
        [Required(ErrorMessage = "SGK numarası alanı gereklidir.")]
        public string SGK_No { get; set; }
        [Required(ErrorMessage = "Askerlik durum alanı gereklidir.")]
        public string MilitaryStatus { get; set; }
        [Required(ErrorMessage = "Medeni hal durum alanı gereklidir.")]
        public string MaritalStatus { get; set; }
        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Araç alanı gereklidir.")]
        public string Vehicle { get; set; }
        public string VehicleRegistrationPlate { get; set; }
        [Required(ErrorMessage = "Yakının ismi alanı gereklidir.")]
        public string NameOfRelative { get; set; }
        [Required(ErrorMessage = "Yakının soyismi alanı gereklidir.")]
        public string SurnameOfRelative { get; set; }
        [Required(ErrorMessage = "Yakının telefon alanı gereklidir.")]
        public string PhoneOfRelative { get; set; }
        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Firma alanı gereklidir.")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Sorumluluk merkezi alanı gereklidir.")]
        public string S_Central { get; set; }
        [Required(ErrorMessage = "Amir alanı gereklidir.")]
        public string Chief { get; set; }
        [Required(ErrorMessage = "Pozisyon alanı gereklidir.")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Başlangıç tarih alanı gereklidir.")]
        public string StartingDate { get; set; }
        [Required(ErrorMessage = "Maaş alanı gereklidir.")]
        public string Salary { get; set; }
        public string English_speak { get; set; }
        public string English_write { get; set; }
        public string English_read { get; set; }
        public string German_speak { get; set; }
        public string German_write { get; set; }
        public string German_read { get; set; }
        public string French_speak { get; set; }
        public string French_write { get; set; }
        public string French_read { get; set; }
        public string OtherLanguage { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string SchoolGraduation { get; set; }
        public string Grade { get; set; }
        [Required(ErrorMessage = "Hastalık durum alanı gereklidir.")]
        public string DiseaseState { get; set; }
        [Required(ErrorMessage = "Sağlık durum alanı gereklidir.")]
        public string HealthSituation { get; set; }
        [Required(ErrorMessage = "Ehliyet alanı gereklidir.")]
        public string DrivingLicense { get; set; }
        [Required(ErrorMessage = "Mesai alanı gereklidir.")]
        public string Shift { get; set; }
        [Required(ErrorMessage = "Sigara alanı gereklidir.")]
        public string Smoke { get; set; }
        [Required(ErrorMessage = "Alkol alanı gereklidir.")]
        public string Alcohol { get; set; }
        [Required(ErrorMessage = "Profil fotoğraf alanı gereklidir.")]
        public string ProfileImage { get; set; }
        [Required(ErrorMessage = "Para birim alanı gereklidir.")]
        public string CurrencyUnit { get; set; }
    }
}
