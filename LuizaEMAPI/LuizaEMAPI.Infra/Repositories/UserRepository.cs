using LuizaEMAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Contexts;
using LuizaEMAPI.Domain.Commands.UserCommand;

namespace LuizaEMAPI.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LuizaEMAPIDataContext _context;

        public UserRepository(LuizaEMAPIDataContext context)
        {
            _context = context;
        }

        public void Delete(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<UserCommand> Get()
        {
            return _context
                .Users
                .Select(u => new UserCommand
                {
                    Name = u.Name,
                    Email = u.Email,
                    //Password = u.Password,
                    Permission = (int)u.Permission,
                    Active = u.Active
                })
            .OrderBy(u => u.Name)
            .ToList();
        }

        public User Get(Guid id)
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
                           Name = u.Name,
                           Email = u.Email,
                           //Password = u.Password,
                           Permission = (int)u.Permission,
                           Active = u.Active
                       })
                   .OrderBy(u => u.Name)
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
            return _context.Users.Any(x => x.Email == user.Email || x.Name == user.Name);
        }
    }
}
