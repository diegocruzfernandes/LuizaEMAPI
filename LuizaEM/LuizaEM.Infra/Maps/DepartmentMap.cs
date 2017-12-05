using LuizaEM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Infra.Maps
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable("Department");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.Description).IsOptional().HasMaxLength(200);
            Property(x => x.Active);
        }
    }
}
