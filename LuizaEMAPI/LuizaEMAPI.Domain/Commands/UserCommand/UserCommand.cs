using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.UserCommand
{
    public class UserCommand : Notifiable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        // public string Password { get; set; }
        public int Permission { get; set; }
        public bool Active { get; set; }
    }
}
