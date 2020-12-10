using Scrypt;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Common.Helpers;
using zeynerp.Common.Messages;
using zeynerp.DAL.Repository;
using zeynerp.Entities;
using zeynerp.Entities.ViewModels;

namespace zeynerp.BL
{
    public class Manager<T> where T : class
    {
        private BL_Result<User> result_user = new BL_Result<User>();
        private BL_Result<Employee> result_employee = new BL_Result<Employee>();

        private UserRepository<User> repo_user = new UserRepository<User>();

        ScryptEncoder scryptEncoder = new ScryptEncoder();
        public BL_Result<User> Register(RegisterViewModel registerViewModel)
        {
            User user = repo_user.Find(x => x.Email == registerViewModel.Email);

            if (user != null)
            {
                result_user.addError(ErrorMessages.RegisteredUser, "Kayıtlı kullanıcı");
            }
            else
            {
                string scryptPassword = scryptEncoder.Encode(registerViewModel.Password);
                string companyId = Guid.NewGuid().ToString().Substring(0, 8);

                if (registerViewModel.CompanyId == null)
                {
                    repo_user.Insert(new User()
                    {
                        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(registerViewModel.Name) ,
                        Surname = registerViewModel.Surname.ToUpper(),
                        Email = registerViewModel.Email,
                        Password = scryptPassword,
                        Repassword = scryptPassword,
                        IsAdmin = false,
                        IsActive = false,
                        CompanyName = registerViewModel.CompanyName.ToUpper(),
                        CompanyId = companyId,
                        Birthday = DateTime.Now,
                        Guid = Guid.NewGuid()
                    });
                }
                else
                {
                    repo_user.Insert(new User()
                    {
                        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(registerViewModel.Name),
                        Surname = registerViewModel.Surname.ToUpper(),
                        Email = registerViewModel.Email,
                        Password = scryptPassword,
                        Repassword = scryptPassword,
                        IsAdmin = false,
                        IsActive = false,
                        CompanyId = registerViewModel.CompanyId,
                        Birthday = DateTime.Now,
                        Guid = Guid.NewGuid()
                    });
                }

                result_user.Result = repo_user.Find(x => x.Email == registerViewModel.Email);

                string body = "Hello " + result_user.Result.Name + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("{0}://{1}/Home/Activation/{2}", "https", "localhost:44394", result_user.Result.Guid) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";

                MailHelper mailHelper = new MailHelper();
                mailHelper.SendMail(result_user.Result.Email, body);
            }

            return result_user;
        }
        public void ManagePassword(Employee employee , string newPassword)
        {
            Repository<Employee> repo = new Repository<Employee>(employee.CompanyName);
            string encryptPass = scryptEncoder.Encode(newPassword);
            repo.UpdatePassword(employee, encryptPass);
            
            repo_user.UpdatePass(employee.Email, encryptPass);
            
        }

        public void Activation(Guid guid)
        {
            User user = repo_user.Find(x => x.Guid == guid);
            
            if (user != null)
            {
                user.IsActive = true;
                repo_user.Update(user);

                User searchEmployeeAdmin = repo_user.Find(x => x.CompanyId == user.CompanyId);
                if(searchEmployeeAdmin != null)
                {
                    user.CompanyName = searchEmployeeAdmin.CompanyName;
                }
                Repository<Employee> repo = new Repository<Employee>(user.CompanyName);
                string scryptPassword = scryptEncoder.Encode(user.Password);

                if(repo.List().Count > 0)
                {
                    user.CompanyName = user.CompanyName;
                    repo_user.Update(user);

                    repo.Insert(new Employee()
                    {
                        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase( user.Name),
                        Surname=user.Surname.ToUpper(),
                        Email = user.Email,
                        Password = scryptPassword,
                        Repassword = scryptPassword,
                        IsAdmin = false,
                        IsActive = true,
                        CompanyName = user.CompanyName,
                        CompanyId = user.CompanyId,
                        Guid = Guid.NewGuid()
                    });
                }
                else
                {
                    repo.Insert(new Employee()
                    {
                        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.Name),
                        Surname = user.Surname.ToUpper(),
                        Email = user.Email,
                        Password = scryptPassword,
                        Repassword = scryptPassword,
                        IsAdmin = true,
                        IsActive = true,
                        CompanyName = user.CompanyName,
                        CompanyId = user.CompanyId,
                        Guid = Guid.NewGuid()
                    });
                }
            }
        }

        public List<Employee> GetCustomer(Employee employeeModel)
        {
            Repository<Employee> repo = new Repository<Employee>(employeeModel.CompanyName);
            var list = repo.List();
            return list;
        }
        public BL_Result<Employee> Login(LoginViewModel loginViewModel)
        {
            User user = repo_user.Find(x => x.Email == loginViewModel.Email);
            Repository<Employee> repo = new Repository<Employee>(user.CompanyName);
            bool isEqual = scryptEncoder.Compare(loginViewModel.Password, user.Password);

            Employee employee = repo.Find(x => x.Email == loginViewModel.Email && x.IsActive == true && isEqual == true);
            if (employee == null)
            {
                result_employee.addError(ErrorMessages.UserNotFound, "Kullanıcı bulunamadı");
            }
            else
            {
                result_employee.Result = repo.Find(x => x.Email == loginViewModel.Email);
            }
            return result_employee;
        }

        public BL_Result<Employee> EditProfile(Employee employeeModel)
        {
            //Repository<Employee> repo = new Repository<Employee>(employeeModel.CompanyName);
            //Employee employee = repo.Find(x => x.Id == employeeModel.Id);
            //if (employee != null)
            //{
            //    employee.ProfileImage = employeeModel.ProfileImage;
            //    repo.Update(employee);

            //    result_employee.Result = repo.Find(x => x.Id == employee.Id);
            //}
            return result_employee;
        }

        public Employee getCustomerId(Employee employeeModel, int id)
        {
            Repository<Employee> repo = new Repository<Employee>(employeeModel.CompanyName);
            Employee employee = repo.Find(x => x.Id == id);
            return employee;
        }
    }
}
