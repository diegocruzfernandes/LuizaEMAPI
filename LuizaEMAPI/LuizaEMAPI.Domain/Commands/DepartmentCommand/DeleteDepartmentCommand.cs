using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.DepartmentCommand
{
    public class DeleteDepartmentCommand
    {
        public DeleteDepartmentCommand(Guid id, string name, string description, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
