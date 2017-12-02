using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.DepartmentCommand
{
    public class DepartmentCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
