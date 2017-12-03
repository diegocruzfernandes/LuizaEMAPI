using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Infra.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable("Department");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.Description).IsRequired().HasMaxLength(200);
            Property(x => x.Active);
        }
    }
}
