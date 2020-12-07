using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.DAL
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GrupModule> GrupModules { get; set; }
        public DbSet<Remainder> Remainders { get; set; }
        public DbSet<Deneme> Denemes { get; set; }
    }


    
}
