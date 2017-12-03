using LuizaEMAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Commands.UserCommand;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Domain.Repositories;
using LuizaEMAPI.Domain.Common;

namespace LuizaEMAPI.AppService
{
    public class UserAppService : IUserAppService
    {

        private readonly IUserRepository _repository;

        public UserAppService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserCommand Create(CreateUserCommand command)
        {
            var user = new User(command.Name, command.Email, command.Password, (EPermission)command.Permission, command.Active);

            var rep = _repository.UserExists(user);

            if (rep)
            {
                var usernull = ConvertUserToUserCmdAndAddNotifications(user);
                usernull.AddNotification("User", "Usuário já cadastrado!");
                return usernull;
            };



            if (user.Valid)
                _repository.Save(user);

            var usercmd = ConvertUserToUserCmdAndAddNotifications(user);
            
            return usercmd;
        }

        public UserCommand Delete(Guid id)
        {
            var user = _repository.Get(id);

            if (user == null)
                user.AddNotification("User", "Não foi encontrado o usúario solicitado");
            else
                _repository.Delete(user);

            var usercmd = ConvertUserToUserCmdAndAddNotifications(user);

            return usercmd;
        }

        public IEnumerable<UserCommand> Get()
        {
            return _repository.Get();
        }

        public UserCommand Get(Guid id)
        {
            var usercmd = ConvertUserToUserCmdAndAddNotifications(_repository.Get(id));
            return usercmd;
        }

        public IEnumerable<UserCommand> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public UserCommand Update(EditUserCommand command)
        {
            var user = _repository.Get(command.Id);

            user.ChangeName(command.Name);
            user.ChangeEmail(command.Email);
            if (command.Active) user.Activate(); else user.Deactivate();

            if (user.Valid)
                _repository.Update(user);

            var usercmd = ConvertUserToUserCmdAndAddNotifications(user);

            return usercmd;
        }

        private UserCommand ConvertUserToUserCmdAndAddNotifications(User user)
        {
            var usercmd = new UserCommand
            {
                Name = user.Name,
                Email = user.Email,
                //Password = user.Password,
                Permission = (int)user.Permission,
                Active = user.Active
            };

            usercmd.AddNotifications(user.Notifications);

            return usercmd;
        }
    }
}
