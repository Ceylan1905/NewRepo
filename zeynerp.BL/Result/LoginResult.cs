using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Common.Messages;
using zeynerp.Entities;

namespace zeynerp.BL.Result
{
    public class LoginResult
    {
        public BL_Result<User> BL_ResultUser { get; set; }
        public BL_Result<Employee> BL_ResultEmployee { get; set; }
        public List<string> Messages { get; set; }

        public void addError(ErrorMessages errorMessages, string text)
        {
            Messages.Add(text);
        }
        public LoginResult()
        {
            BL_ResultUser = new BL_Result<User>();
            BL_ResultEmployee = new BL_Result<Employee>();
            Messages = new List<string>();
        }
    }
}
