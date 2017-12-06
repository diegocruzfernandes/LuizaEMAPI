using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using System.Collections.Generic;

namespace LuizaEM.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserCommand> Get();
        IEnumerable<UserCommand> Get(int skip, int take);
        User Get(int id);
        User GetByEmail(string email);
        void Save(User user);
        void Update(User user);
        void Delete(User user);
        bool UserExists(User user);
    }
}
