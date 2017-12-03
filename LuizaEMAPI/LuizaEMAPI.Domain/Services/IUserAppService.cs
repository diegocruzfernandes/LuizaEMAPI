using LuizaEMAPI.Domain.Commands.UserCommand;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Services
{
    public interface IUserAppService
    {
        IEnumerable<UserCommand> Get();
        IEnumerable<UserCommand> Get(int skip, int take);
        UserCommand Get(Guid id);
        User GetByEmail(string email);
        UserCommand Create(CreateUserCommand command);
        UserCommand Update(EditUserCommand command);
        UserCommand Delete(Guid id);
    }
}
