using FluentValidator.Validation;
using LuizaEMAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Entities
{
    public class Employee : Entity
    {
        protected Employee() { }

        public Employee(string firstName, string lastName, string email, Department department, DateTime birthDate, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            BirthDate = birthDate;
            Active = active;

            Validate();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Department Department { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
            Validate();
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangeDepartment(Department depart)
        {
            Department = depart;
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O  nome não pode ser menor que 3 caracteres")
                .HasMaxLen(FirstName, 60, "FirstName", "O  nome não pode ser maior que 60 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O  nome não pode ser menor que 3 caracteres")
                .HasMaxLen(LastName, 60, "LastName", "O  nome não pode ser maior que 60 caracteres")
                .HasMinLen(Email, 10, "Email", "O  e-mail não pode ser menor que 10 caracteres")
                .HasMaxLen(Email, 50, "Email", "O  e-mail não pode ser maior que 50 caracteres")
                .IsEmail(Email, "Email", "E-mail no formato inválido")
                .IsNotNullOrEmpty(Department.ToString(), "Departament", "O Departamento não pode ficar fazio!")
                .IsGreaterThan(BirthDate, new DateTime(), "BirthDate", "Data inválida")
                 );
        }

    }


}
