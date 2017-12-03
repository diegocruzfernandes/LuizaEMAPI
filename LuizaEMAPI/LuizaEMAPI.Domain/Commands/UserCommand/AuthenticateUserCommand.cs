using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.UserCommand
{
    public class AuthenticateUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
