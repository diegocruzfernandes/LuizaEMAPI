using LuizaEMAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Department Department { get; private set; }
        public bool Active { get; private set; }
    }
}
