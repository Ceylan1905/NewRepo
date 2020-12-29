using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;
using zeynerp.Entities.Admin;

namespace zeynerp.DAL
{
    class UserContext : DbContext
    {
        public UserContext() : base("name=DefaultConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
<<<<<<< HEAD
        public DbSet<Module> Modules { get; set; }
        public DbSet<Log> Logs { get; set; }
=======
>>>>>>> 3add85628d495cc3f28fe48654a30f16067554cc
    }
}
