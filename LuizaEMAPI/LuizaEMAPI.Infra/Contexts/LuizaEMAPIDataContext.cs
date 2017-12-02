using LuizaEMAPI.Domain.Entities;
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
    }
}
