using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.HumanResource
{
    public class Personnel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string Tc_No { get; set; }
        [Required]
        public string SGK_No { get; set; }
        [Required]
        public string MilitaryStatus { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Vehicle { get; set; }
        public string VehicleRegistrationPlate { get; set; }
        [Required]
        public string NameOfRelative { get; set; }
        [Required]
        public string SurnameOfRelative { get; set; }
        [Required]
        public string PhoneOfRelative { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string S_Central { get; set; }
        [Required]
        public string Chief { get; set; }
        [Required]
        public string Position { get; set; }
        public string StartingDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
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
        [Required]
        public string DiseaseState { get; set; }
        [Required]
        public string HealthSituation { get; set; }
        public string DrivingLicense { get; set; }
        public string Shift { get; set; }
        public string Smoke { get; set; }
        public string Alcohol { get; set; }
        public string ProfileImage { get; set; }
    }
}
