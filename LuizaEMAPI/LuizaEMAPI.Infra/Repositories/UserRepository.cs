using LuizaEMAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Contexts;

namespace LuizaEMAPI.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LuizaEMAPIDataContext _context;

        public UserRepository(LuizaEMAPIDataContext context)
        {
            _context = context;
        }

        public User Get(Guid id)
        {
            return _context
                .Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);                 
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public bool UserExists(User user)
        {
            return _context.Users.Any(x => x.Email == user.Email || x.Name == user.Name);
        }
    }
}
