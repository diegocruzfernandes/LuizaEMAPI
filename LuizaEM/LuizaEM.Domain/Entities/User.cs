using FluentValidator;
using LuizaEM.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Entities
{
    public class User : Notifiable
    {
        protected User() { }

        public User(int id, string username, string email, string password, EPermission permission, bool active)
        {
            Id = id;
            Username = username;
            Email = email.ToLower();
            Password = password;
            Permission = permission;
            Active = active;

            Validate();

            Password = ValidationPassword.Encrypt(password);
        }

        public int Id { get; private set; }
        public string Username { get; private set; } 
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

        public string ResetPassword()
        {
            string pass = Guid.NewGuid().ToString().Substring(0, 6);
            Password = ValidationPassword.Encrypt(pass);
            return pass;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void ChangeUserName(string username)
        {
            Username = username;
            Validate();
        }

        public void ChangePermission(EPermission permission)
        {
            Permission = permission;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void Validate()
        {
            new ValidationContract<User>(this)
                .HasMinLenght(x => x.Username, 3, "O  nome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.Username, 60, "O  nome não pode ser maior que 60 caracteres")
                .HasMinLenght(x => x.Email, 10, "O e-mail não pode ser menor que 10 caracteres")
                .HasMaxLenght(x => x.Email, 60, "O e-mail não pode ser maior que 60 caracteres")
                .IsEmail(x => x.Email, "Email no formato inválido")
                .HasMinLenght(x => x.Password, 3, "O Password não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.Password, 60, "O Password não pode ser maio que 60 caracteres")
                .IsNotNull(Permission, "A permissão não pode ser nula ou vazia");
        }
    }

}
