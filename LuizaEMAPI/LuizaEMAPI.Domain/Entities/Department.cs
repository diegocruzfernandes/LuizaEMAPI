
using FluentValidator.Validation;
using LuizaEMAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Entities
{
    public class Department : Entity
    {
        protected Department(){ }

        public Department(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;

            Validate();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .HasMinLen(Name, 3, "Nome", "O  nome não pode ser menor que 3 caracteres")
                 .HasMaxLen(Name, 60, "Nome", "O  nome não pode ser maior que 60 caracteres")
                 .HasMaxLen(Description, 200, "Description", "A descrição não pode ser maior que 200 caracteres")
                );
        }
    }
}
