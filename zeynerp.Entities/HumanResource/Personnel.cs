using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities.HumanResource
{
    public class Personnel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public int TC_No { get; set; }
        [Required]
        public int SGK_No { get; set; }
        [Required]
        public string MilitaryStatus { get; set; }
        public bool MaritalStatus { get; set; }
        [Required]
        public int Phone { get; set; }
        public bool Vehicle { get; set; }
        public bool VehicleLicensePlate { get; set; }
        [Required]
        public string RelativeName { get; set; }
        [Required]
        public string RelativeSurname { get; set; }
        [Required]
        public int RelativePhone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string S_Central { get; set; }
        [Required]
        public string Chief { get; set; }
        public DateTime StartingDate { get; set; }
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
        public string SchoolSection { get; set; }
        public DateTime? SchoolGraduation { get; set; }
        public float? SchoolGradeAverage { get; set; }
        [Required]
        public string DiseaseState { get; set; }
        [Required]
        public string HealthSituation { get; set; }
        public bool IsDrivingLicense { get; set; }
        public bool Shift { get; set; }
        public bool Smoke { get; set; }
        public bool Alcohol { get; set; }
    }
}
