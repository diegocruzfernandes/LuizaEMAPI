using FluentValidator;
using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using System.Collections.Generic;

namespace LuizaEM.Domain.Services
{
    public interface IUserAppService
    {
        IEnumerable<UserCommand> Get();
        IEnumerable<UserCommand> Get(int skip, int take);
        UserCommand Get(int id);
        User GetByEmail(string email);
        UserCommand Create(CreateUserCommand command);
        UserCommand Update(EditUserCommand command);
        UserCommand Delete(int id);
        User ResetPassword(int id);
        IEnumerable<Notification> Validate();
    }
}
