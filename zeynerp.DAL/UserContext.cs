using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.DAL
{
    class UserContext : DbContext
    {
        public UserContext() : base("name=DefaultConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
