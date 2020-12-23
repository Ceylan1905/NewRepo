using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;
using zeynerp.Entities.ViewModels;

namespace zeynerp.BL
{
    public class HumanResourceManager<T> where T : class
    {
        private BL_Result<Personnel> result_personnel = new BL_Result<Personnel>();
        private SelectViewModel selectViewModel = new SelectViewModel();

        public BL_Result<Personnel> GetPersonnel(string db_name, int id)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            result_personnel.Result = repo_personnel.Find(x => x.Id == id);
            return result_personnel;
        }
        public List<Personnel> GetPersonnels(string db_name, SelectViewModel selectViewModel)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);

            if (selectViewModel.Company != null)
            {
                if (selectViewModel.Company == "all")
                {
                    List<Personnel> personnelListAll = repo_personnel.List();
                    return personnelListAll;
                }
                List<Personnel> personnelListFilter = repo_personnel.List(x => x.Company == selectViewModel.Company);
                return personnelListFilter;
            }
            else if (selectViewModel.S_Central != null)
            {
                if (selectViewModel.S_Central == "all")
                {
                    List<Personnel> personnelListAll = repo_personnel.List();
                    return personnelListAll;
                }
                List<Personnel> personnelListFilter = repo_personnel.List(x => x.S_Central == selectViewModel.S_Central);
                return personnelListFilter;
            }
            else if (selectViewModel.Position != null)
            {
                if (selectViewModel.Position == "all")
                {
                    List<Personnel> personnelListAll = repo_personnel.List();
                    return personnelListAll;
                }
                List<Personnel> personnelListFilter = repo_personnel.List(x => x.Position == selectViewModel.Position);
                return personnelListFilter;
            }

            List<Personnel> personnelList = repo_personnel.List();
            return personnelList;
        }
        public BL_Result<Personnel> PersonnelAdd(string db_name, Personnel personnel)
        {
            if(personnel != null)
            {
                Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
                int db = repo_personnel.Insert(new Personnel()
                {
                    Name = personnel.Name,
                    Surname = personnel.Surname,
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
                    Alcohol = personnel.Alcohol,
                    ProfileImage = personnel.ProfileImage,
                    CurrencyUnit = personnel.CurrencyUnit
                });

                if(db > 0)
                {
                    result_personnel.Result = repo_personnel.Find(x => x.Id == personnel.Id);
                }
            }
            return result_personnel;
        }
        public BL_Result<Personnel> PersonnelUpdate(string db_name, BL_Result<Personnel> per)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            Personnel personnel = repo_personnel.Find(x => x.Id == per.Result.Id);
            if(personnel != null)
            {
                personnel.Name = per.Result.Name;
                personnel.Surname = per.Result.Surname;
                personnel.City = per.Result.City;
                personnel.Birthday = per.Result.Birthday;
                personnel.Tc_No = per.Result.Tc_No;
                personnel.SGK_No = per.Result.SGK_No;
                personnel.MilitaryStatus = per.Result.MilitaryStatus;
                personnel.MaritalStatus = per.Result.MaritalStatus;
                personnel.Phone = per.Result.Phone;
                personnel.Vehicle = per.Result.Vehicle;
                personnel.VehicleRegistrationPlate = per.Result.VehicleRegistrationPlate;
                personnel.NameOfRelative = per.Result.NameOfRelative;
                personnel.SurnameOfRelative = per.Result.SurnameOfRelative;
                personnel.PhoneOfRelative = per.Result.PhoneOfRelative;
                personnel.Address = per.Result.Address;
                personnel.Company = per.Result.Company;
                personnel.S_Central = per.Result.S_Central;
                personnel.Chief = per.Result.Chief;
                personnel.Position = per.Result.Position;
                personnel.StartingDate = per.Result.StartingDate;
                personnel.Salary = per.Result.Salary;
                personnel.English_speak = per.Result.English_speak;
                personnel.English_write = per.Result.English_write;
                personnel.English_read = per.Result.English_read;
                personnel.German_speak = per.Result.German_speak;
                personnel.German_write = per.Result.German_write;
                personnel.German_read = per.Result.German_read;
                personnel.French_speak = per.Result.French_speak;
                personnel.French_write = per.Result.French_write;
                personnel.French_read = per.Result.French_read;
                personnel.OtherLanguage = per.Result.OtherLanguage;
                personnel.SchoolName = per.Result.SchoolName;
                personnel.Section = per.Result.Section;
                personnel.SchoolGraduation = per.Result.SchoolGraduation;
                personnel.Grade = per.Result.Grade;
                personnel.DiseaseState = per.Result.DiseaseState;
                personnel.HealthSituation = per.Result.HealthSituation;
                personnel.DrivingLicense = per.Result.DrivingLicense;
                personnel.Shift = per.Result.Shift;
                personnel.Smoke = per.Result.Smoke;
                personnel.Alcohol = per.Result.Alcohol;
                personnel.ProfileImage = per.Result.ProfileImage;
                personnel.CurrencyUnit = per.Result.CurrencyUnit;
            }
            repo_personnel.Update(personnel);
            return result_personnel;
        }
        public void PersonnelDelete(string db_name, int id)
        {
            Repository<Personnel> repo_personnel = new Repository<Personnel>(db_name);
            Personnel personnel = repo_personnel.Find(x => x.Id == id);
            if(personnel != null)
            {
                repo_personnel.Delete(personnel);
            }
        }
    }
}
