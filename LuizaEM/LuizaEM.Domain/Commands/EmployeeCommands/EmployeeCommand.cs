using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Commands.EmployeeCommands
{
    public class EmployeeCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

    }
}
