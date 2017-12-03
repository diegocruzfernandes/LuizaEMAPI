using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.DepartmentCommand
{
    public class CreateDepartmentCommand
    {
        public CreateDepartmentCommand(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
