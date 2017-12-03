using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.UserCommand
{
    public class CreateUserCommand
    {
        public CreateUserCommand(string name, string email, string password, int permission, bool active)
        {
            Name = name;
            Email = email;
            Password = password;
            Permission = permission;
            Active = active;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public bool Active { get; set; }
    }

}
