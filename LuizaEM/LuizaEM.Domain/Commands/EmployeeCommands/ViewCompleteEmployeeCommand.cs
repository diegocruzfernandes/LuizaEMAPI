using System;

namespace LuizaEM.Domain.Commands.EmployeeCommands
{
    public class ViewCompleteEmployeeCommand
    {
        public ViewCompleteEmployeeCommand(int id, string firstName, string lastName, string email, string department, DateTime birthDate, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            BirthDate = birthDate;
            Active = active;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }        
    }
}
