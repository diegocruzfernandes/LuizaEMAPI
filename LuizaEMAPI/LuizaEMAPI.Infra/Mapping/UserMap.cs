using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Infra.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.Email).IsRequired().HasMaxLength(50);
            Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Permission);
            Property(x => x.Active); 


        }
    }
}
