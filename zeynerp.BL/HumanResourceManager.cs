using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;

namespace zeynerp.BL
{
    public class HumanResourceManager<T> where T : class
    {
        private BL_Result<Personnel> result_personnel = new BL_Result<Personnel>();

        public BL_Result<Personnel> PersonnelAdd(string db_name, Personnel personnel)
        {
            if(personnel != null)
            {
                Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
                Personnel db_personnel = repo_personnel.Find(x => x.Id == personnel.Id);
                if(db_personnel != null)
                {
                    db_personnel.Name = personnel.Name;
                    db_personnel.Surname = personnel.Surname;
                    db_personnel.City = personnel.City;
                    db_personnel.Birthday = personnel.Birthday;
                    db_personnel.Tc_No = personnel.Tc_No;
                    db_personnel.SGK_No = personnel.SGK_No;
                    db_personnel.MilitaryStatus = personnel.MilitaryStatus;
                    db_personnel.MaritalStatus = personnel.MaritalStatus;
                    db_personnel.Phone = personnel.Phone;
                    db_personnel.Vehicle = personnel.Vehicle;
                    db_personnel.VehicleRegistrationPlate = personnel.VehicleRegistrationPlate;
                    db_personnel.NameOfRelative = personnel.NameOfRelative;
                    db_personnel.SurnameOfRelative = personnel.SurnameOfRelative;
                    db_personnel.PhoneOfRelative = personnel.PhoneOfRelative;
                    db_personnel.Address = personnel.Address;
                    db_personnel.Company = personnel.Company;
                    db_personnel.S_Central = personnel.S_Central;
                    db_personnel.Chief = personnel.Chief;
                    db_personnel.Position = personnel.Position;
                    db_personnel.StartingDate = personnel.StartingDate;
                    db_personnel.Salary = personnel.Salary;
                    db_personnel.English_speak = personnel.English_speak;
                    db_personnel.English_write = personnel.English_write;
                    db_personnel.English_read = personnel.English_read;
                    db_personnel.German_speak = personnel.German_speak;
                    db_personnel.German_write = personnel.German_write;
                    db_personnel.German_read = personnel.German_read;
                    db_personnel.French_speak = personnel.French_speak;
                    db_personnel.French_write = personnel.French_write;
                    db_personnel.French_read = personnel.French_read;
                    db_personnel.OtherLanguage = personnel.OtherLanguage;
                    db_personnel.SchoolName = personnel.SchoolName;
                    db_personnel.Section = personnel.Section;
                    db_personnel.SchoolGraduation = personnel.SchoolGraduation;
                    db_personnel.Grade = personnel.Grade;
                    db_personnel.DiseaseState = personnel.DiseaseState;
                    db_personnel.HealthSituation = personnel.HealthSituation;
                    db_personnel.DrivingLicense = personnel.DrivingLicense;
                    db_personnel.Shift = personnel.Shift;
                    db_personnel.Smoke = personnel.Smoke;
                    db_personnel.Alcohol = personnel.Alcohol;

                    repo_personnel.Update(db_personnel);

                    result_personnel.Result = repo_personnel.Find(x => x.Id == personnel.Id);
                }
                else
                {
                    repo_personnel.Insert(new Personnel()
                    {
                        Name = personnel.Name,
                        Surname = personnel.Surname.ToUpper(),
                        City = personnel.City,
                        Birthday = personnel.Birthday,
                        Tc_No = personnel.Tc_No,
                        SGK_No = personnel.SGK_No,
                        MilitaryStatus = personnel.MilitaryStatus,
                        MaritalStatus = personnel.MaritalStatus,
                        Phone = personnel.Phone,
                        Vehicle = personnel.Vehicle,
                        VehicleRegistrationPlate = personnel.VehicleRegistrationPlate,
                        NameOfRelative = personnel.NameOfRelative,
                        SurnameOfRelative = personnel.SurnameOfRelative,
                        PhoneOfRelative = personnel.PhoneOfRelative,
                        Address = personnel.Address,
                        Company = personnel.Company,
                        S_Central = personnel.S_Central,
                        Chief = personnel.Chief,
                        Position = personnel.Position,
                        StartingDate = personnel.StartingDate,
                        Salary = personnel.Salary,
                        English_speak = personnel.English_speak,
                        English_write = personnel.English_write,
                        English_read = personnel.English_read,
                        German_speak = personnel.German_speak,
                        German_write = personnel.German_write,
                        German_read = personnel.German_read,
                        French_speak = personnel.French_speak,
                        French_write = personnel.French_write,
                        French_read = personnel.French_read,
                        OtherLanguage = personnel.OtherLanguage,
                        SchoolName = personnel.SchoolName,
                        Section = personnel.Section,
                        SchoolGraduation = personnel.SchoolGraduation,
                        Grade = personnel.Grade,
                        DiseaseState = personnel.DiseaseState,
                        HealthSituation = personnel.HealthSituation,
                        DrivingLicense = personnel.DrivingLicense,
                        Shift = personnel.Shift,
                        Smoke = personnel.Smoke,
                        Alcohol = personnel.Alcohol
                });

                    result_personnel.Result = repo_personnel.Find(x => x.Id == personnel.Id);
                }
            }
            return result_personnel;
        }

        public List<Personnel> GetPersonnels(string db_name)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            
            if(repo_personnel.List() == null)
            {
                // Error
            }
            
            List<Personnel> personnelList = repo_personnel.List();
            return personnelList;
        }

        public Personnel GetPersonnel(string db_name, int id)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            Personnel personnel = repo_personnel.Find(x => x.Id == id);
            if (personnel == null)
            {
                // Error
            }
            return personnel;
        }

        public Personnel PersonnelDelete(string db_name, int id)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            Personnel personnel = repo_personnel.Find(x => x.Id == id);
            if(personnel != null)
            {
                repo_personnel.Delete(personnel);
            }
            return personnel;
        }
    }
}
