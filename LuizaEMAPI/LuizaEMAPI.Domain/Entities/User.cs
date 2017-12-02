using FluentValidator.Validation;
using LuizaEMAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Entities
{
    public class User : Entity, IValidatable
    {
        protected User() { }

        public User(string name, string email, string password, EPermission permission, bool active)
        {
            Name = name;
            Email = email;
            Password = password;
            Permission = permission;
            Active = true;

            Validate();
            Password = ValidationPassword.Encrypt(password);
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public EPermission Permission { get; private set; }
        public bool Active { get; private set; }

        public bool Authenticate(string email, string password)
        {
            if (Email == email && Password == ValidationPassword.Encrypt(password))
                return true;

            AddNotification("User", "Usuário ou senha inválido");
            return false;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public string ResetPassword()
        {
            string pass = Guid.NewGuid().ToString().Substring(0, 6);
            Password = ValidationPassword.Encrypt(pass);
            return pass;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .HasMinLen(Name, 3, "Nome", "O  nome não pode ser menor que 3 caracteres")
                 .HasMaxLen(Name, 60, "Nome", "O  nome não pode ser maior que 60 caracteres")
                 .HasMinLen(Email, 10, "Email", "O  e-mail não pode ser menor que 10 caracteres")
                 .HasMaxLen(Email, 50, "Email", "O  e-mail não pode ser maior que 50 caracteres")
                 .IsEmail(Email, "Email", "Email no formato inválido")
                 .HasMinLen(Password, 3, "Password", "O Password não pode ser menor que 3 caracteres")
                 .HasMaxLen(Password, 60, "Password", "O Password não pode ser maior que 60 caracteres")
                 .IsNotNullOrEmpty(Permission.ToString(), Permission.ToString(), "A permissão não pode ser nula ou vazia")
                 );
        }


    }
}
