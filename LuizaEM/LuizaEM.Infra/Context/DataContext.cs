using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Shared;
using LuizaEM.Infra.Maps;
using System.Data.Entity;

namespace LuizaEM.Infra.Context
{
   
    public class DataContext : DbContext
    {
        //Local = @"Data Source=DON\SQLEXPRESS;Initial Catalog=LuizaDB; User ID=sa; Password=admin;"
        public DataContext() : base(Runtime.ConnectionString)
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
