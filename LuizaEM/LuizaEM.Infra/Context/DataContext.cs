using LuizaEM.Domain.Entities;
using LuizaEM.Infra.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(@"Data Source=DON\SQLEXPRESS;Initial Catalog=LuizaDB; User ID=sa; Password=admin;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
        }
    }
}
