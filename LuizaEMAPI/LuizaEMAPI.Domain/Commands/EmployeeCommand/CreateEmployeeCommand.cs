using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.EmployeeCommand
{
    public class CreateEmployeeCommand
    {
        public CreateEmployeeCommand(string fisrtName, string lastName, string email, Department department, DateTime birthDate, bool active)
        {
            FisrtName = fisrtName;
            LastName = lastName;
            Email = email;
            Department = department;
            BirthDate = birthDate;
            Active = active;
        }

        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
