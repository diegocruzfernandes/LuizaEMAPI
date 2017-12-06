using System;

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

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }  
}
