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
        User Get(Guid id);
        User GetByEmail(string email);
        bool Save(User user);
        bool Update(User user);
        bool UserExists(User user);
    }
}
