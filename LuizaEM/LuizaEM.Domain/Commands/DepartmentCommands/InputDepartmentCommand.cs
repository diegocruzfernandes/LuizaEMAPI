namespace LuizaEM.Domain.Commands.DepartmentCommands
{
    public class InputDepartmentCommand
    {
        public InputDepartmentCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
