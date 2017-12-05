using LuizaEM.Domain.Commands.DepartmentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand
    {
        public CreateEmployeeCommand(string firstName, string lastName, string email, int departmentId, DateTime birthDate, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DepartmentId = departmentId;
            BirthDate = birthDate;
            Active = active;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
