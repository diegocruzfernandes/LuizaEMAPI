using FluentValidator;
using LuizaEM.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Entities
{
    public class Employee : Notifiable
    {
        #region Contructor
        protected Employee() { }

        public Employee(int id, string firstName, string lastName, string email, int departmentId, DateTime birthDate, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email.ToLower();
            DepartmentId = departmentId;           
            BirthDate = birthDate;
            Active = active;

            Validate();
        }
        #endregion

        #region Attribute
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int DepartmentId { get; private set; }
        public virtual Department Department { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region Methods
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void UpdateData(string firstName, string lastName, string email, int departmentId, DateTime birthdate, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DepartmentId = departmentId;
            BirthDate = birthdate;
            Active = active;

            Validate();
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void Validate()
        {
            new ValidationContract<Employee>(this)
                .IsRequired(x=>x.FirstName)
                .HasMinLenght(x => x.FirstName, 3, "O nome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.FirstName, 60, "O nome não pode ser maior que 60 caracteres")
                .IsRequired(x =>x.LastName)
                .HasMinLenght(x => x.LastName, 3, "O sobrenome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.LastName, 60, "O sobrenome não pode ser maior que 60 caracteres")
                .IsRequired(x => x.Email)
                .HasMinLenght(x => x.Email, 10, "O nome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.Email, 60, "O nome não pode ser maior que 60 caracteres")
                .IsEmail(x => x.Email, "E-mail no formato inválido")
                
                .IsGreaterThan(x => x.BirthDate, new DateTime(), "Data inválid");
        }
        #endregion
    }
}
