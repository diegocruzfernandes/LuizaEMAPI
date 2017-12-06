namespace LuizaEM.Domain.Commands.EmployeeCommands
{
    public class ViewSimpleEmployeeCommand
    {
        public ViewSimpleEmployeeCommand(string name, string email, string department)
        {
            Name = name;
            Email = email;
            Department = department;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
