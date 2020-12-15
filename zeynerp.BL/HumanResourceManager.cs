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
                        Address = personnel.Address                        
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
    }
}
