using LuizaEMAPI.Domain.Commands.UserCommand;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserCommand> Get();
        IEnumerable<UserCommand> Get(int skip, int take);
        User Get(Guid id);
        User GetByEmail(string email);
        void Save(User user);
        void Update(User user);
        void Delete(User user);
        bool UserExists(User user);
    }
}
