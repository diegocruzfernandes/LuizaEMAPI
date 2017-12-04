namespace LuizaEM.Domain.Commands.DepartmentCommands
{
    public class EditDepartmentCommand
    {
        public EditDepartmentCommand(int id, string name, string description, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
