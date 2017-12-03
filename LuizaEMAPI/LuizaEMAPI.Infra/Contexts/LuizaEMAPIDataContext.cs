using LuizaEMAPI.Domain.Common;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Mapping;
using System.Data.Entity;

namespace LuizaEMAPI.Infra.Contexts
{
    public class LuizaEMAPIDataContext : DbContext
    {
        public LuizaEMAPIDataContext(): base(Runtime.ConnectionString)
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
