using LuizaEM.Domain.Services;
using System.Collections.Generic;
using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Repositories;
using LuizaEM.Domain.Shared;
using System;

namespace LuizaEM.AppService
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
            var user = new User(0, command.Username, command.Email, command.Password, (EPermission)command.Permission, command.Active);

            var rep = _repository.UserExists(user);

            if (rep)
            {
                var usernull = ConvertUserToUserCmdAndAddNotifications(user);
                usernull.AddNotification("User", "Usuário já cadastrado!");
                return usernull;
            };

            if (user.IsValid())
                _repository.Save(user);

            var usercmd = ConvertUserToUserCmdAndAddNotifications(user);

            return usercmd;
        }

        public UserCommand Delete(int id)
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

        public UserCommand Get(int id)
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

            user.ChangeUserName(command.Username);
            user.ChangeEmail(command.Email);
            if (command.Active) user.Activate(); else user.Deactivate();

            if (user.IsValid())
                _repository.Update(user);

            var usercmd = ConvertUserToUserCmdAndAddNotifications(user);

            return usercmd;
        }

        private UserCommand ConvertUserToUserCmdAndAddNotifications(User user)
        {
            var usercmd = new UserCommand
            {
                Username = user.Username,
                Email = user.Email,
                //Password = user.Password,
                Permission = (int)user.Permission,
                Active = user.Active
            };

            usercmd.AddNotifications(user.Notifications);

            return usercmd;
        }

        public User ResetPassword(int id)
        {
            var user = _repository.Get(id);

            if (user == null)
            {
                user.AddNotification("User", "Usário não encontrado");
                return user;
            }              

            user.ResetPassword();
            //TODO: Salvar e enviar o email
            _repository.Update(user);
            //Enviar EMAIL
            user.AddNotification("User", "a senha nova foi enviada por email");             

            return user;
        }
    }
}
