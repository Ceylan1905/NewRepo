﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connectionString) : base(connectionString)
        {
            var migrationConfiguration = new MigrationConfiguration();
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, MigrationConfiguration>(true, migrationConfiguration));

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GrupModule> GrupModules { get; set; }
        public DbSet<Remainder> Remainders { get; set; }
    }

    public sealed class MigrationConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public MigrationConfiguration()
            : base()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
