using LuizaEMAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Commands.Handler
{
    public class UserCommandHandler
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EPermission Permission { get; set; }
        public bool Active { get; set; }
    }
}
