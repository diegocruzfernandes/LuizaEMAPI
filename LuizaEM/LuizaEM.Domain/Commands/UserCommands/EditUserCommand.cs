namespace LuizaEM.Domain.Commands.UserCommands
{
    public class EditUserCommand
    {
        public EditUserCommand(int id, string username, string email, string password, int permission, bool active)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Permission = permission;
            Active = active;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public bool Active { get; set; }
    }
}
