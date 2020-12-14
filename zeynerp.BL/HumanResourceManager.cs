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

                int db = repo_personnel.Insert(new Personnel()
                {
                    Name = personnel.Name,
                    Surname = personnel.Surname.ToUpper(),
                    City = personnel.City,
                    Birthday = personnel.Birthday,
                    MilitaryStatus = personnel.MilitaryStatus,
                    MaritalStatus = personnel.MaritalStatus,
                    Tc_No = personnel.Tc_No,
                    SGK_No = personnel.SGK_No,
                    Phone = personnel.Phone,
                    Vehicle = personnel.Vehicle,
                    VehicleRegistrationPlate = personnel.VehicleRegistrationPlate,
                    NameOfRelative = personnel.NameOfRelative,
                    SurnameOfRelative = personnel.SurnameOfRelative,
                    PhoneOfRelative = personnel.PhoneOfRelative,
                    Address = personnel.Address
                });

                if(db > 0)
                {
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
