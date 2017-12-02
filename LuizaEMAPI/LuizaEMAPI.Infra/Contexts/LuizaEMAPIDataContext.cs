using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Infra.Contexts
{
    public class LuizaEMAPIDataContext : DbContext
    {



        public LuizaEMAPIDataContext(): base(@"Data Source=.\SQLEXPRESS; Initial Catalog=LuizLabs; User ID=sa; Password=admin")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
        }

    }
}
