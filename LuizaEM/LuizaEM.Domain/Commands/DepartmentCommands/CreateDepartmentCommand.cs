namespace LuizaEM.Domain.Commands.DepartmentCommands
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
