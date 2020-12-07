using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.DAL
{
    public class Singleton
    {
        public DatabaseContext databaseContext;
        public Singleton(string db_name)
        {
            CreateContext(db_name);
        }
        public void CreateContext(string db_name)
        {
            if (databaseContext == null)
            {
                string baseConnectionString = ConfigurationManager.ConnectionStrings["BaseConnectionString"].ConnectionString;
                databaseContext = new DatabaseContext(string.Format(baseConnectionString, db_name));
            }
        }
    }
}
