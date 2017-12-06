using System;

namespace LuizaEM.Domain.Commands.EmployeeCommands
{
    public class DeleteEmployeeCommand
    {
        public DeleteEmployeeCommand(int id, string firstName, string lastName, string email, int departmentId, DateTime birthDate, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DepartmentId = departmentId;
            BirthDate = birthDate;
            Active = active;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
