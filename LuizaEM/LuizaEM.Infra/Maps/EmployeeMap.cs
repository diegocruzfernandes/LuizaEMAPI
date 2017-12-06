using LuizaEM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LuizaEM.Infra.Maps
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employee");
            HasKey(x => x.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            Property(x => x.LastName).IsOptional().HasMaxLength(60);
            Property(x => x.Email).IsRequired().HasMaxLength(60);
            Property(x => x.BirthDate);
            Property(x => x.Active);
            Property(x => x.DepartmentId).IsRequired();
            HasRequired(d => d.Department);
        }
    }
}
