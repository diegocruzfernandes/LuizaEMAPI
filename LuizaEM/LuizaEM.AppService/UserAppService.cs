using LuizaEM.Domain.Services;
using System.Collections.Generic;
using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Repositories;
using LuizaEM.Domain.Shared;
using FluentValidator;

namespace LuizaEM.AppService
{
    public class UserAppService : Notifiable, IUserAppService
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;

        public UserAppService(IUserRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public UserCommand Create(CreateUserCommand command)
        {
            var user = new User(0, command.Username, command.Email, command.Password, (EPermission)command.Permission, command.Active);

            if (_repository.UserExists(user))
            {
                AddNotification("User", "Usuário já cadastrado!");
                return null;
            }

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
                Permission = (int)user.Permission,
                Active = user.Active
            };
            AddNotifications(user.Notifications);
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

            var newPassword = user.ResetPassword();
            _repository.Update(user);
            _emailService.Send(
                user.Username,
                user.Email,
                 string.Format("Luiza Employee Manager - Important", user.Username),
                 string.Format($"Olá, sua nova senha é: {newPassword}.", user.Username)
                );
            return user;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
