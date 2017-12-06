using LuizaEM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Infra.Context;

namespace LuizaEM.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<UserCommand> Get()
        {
            return _context
                .Users
                .Select(u => new UserCommand
                {
                    Username = u.Username,
                    Email = u.Email,
                    //Password = u.Password,
                    Permission = (int)u.Permission,
                    Active = u.Active
                })
            .OrderBy(u => u.Username)
            .ToList();
        }

        public User Get(int id)
        {
            return _context
                 .Users
                 .AsNoTracking()
                 .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserCommand> Get(int skip, int take)
        {
            return _context
                .Users
                .Select(u => new UserCommand
                {
                    Username = u.Username,
                    Email = u.Email,
                    //Password = u.Password,
                    Permission = (int)u.Permission,
                    Active = u.Active
                })
            .OrderBy(u => u.Username)
            .Skip(skip)
            .Take(take)
            .ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Email == email);
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
            return _context.Users.Any(x => x.Email == user.Email || x.Username == user.Username);
        }

        public void Delete(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
