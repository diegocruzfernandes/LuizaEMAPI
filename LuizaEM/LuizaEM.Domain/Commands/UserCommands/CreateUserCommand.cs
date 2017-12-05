namespace LuizaEM.Domain.Commands.UserCommands
{
    public class CreateUserCommand
    {
        public CreateUserCommand(string username, string email, string password, int permission, bool active)
        {
            Username = username;
            Email = email;
            Password = password;
            Permission = permission;
            Active = active;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public bool Active { get; set; }
    }
}
