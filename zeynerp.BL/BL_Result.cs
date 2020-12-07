using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Common.Messages;

namespace zeynerp.BL
{
    public class BL_Result<T> where T : class
    {
        public T Result { get; set; }
        public List<string> Messages { get; set; }

        public List<T> entites { get; set; }
        public BL_Result()
        {
            Messages = new List<string>();
        }

        public void addError(ErrorMessages errorMessages, string text)
        {
            Messages.Add(text);
        }
    }
}
