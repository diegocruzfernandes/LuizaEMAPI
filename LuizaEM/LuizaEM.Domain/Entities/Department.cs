using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Entities
{
    public class Department : Notifiable
    {
        protected Department() { }
        public Department(int id, string name, string description, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;

            Validate();
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }


        public void UpdateData(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;

            Validate();
        }


        public void Activate() => Active = true;
        public void Deactivate() => Active = false;
        public void Validate()
        {
            new ValidationContract<Department>(this)
                .HasMinLenght(x => x.Name, 3, "O  nome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.Name, 60, "O  nome não pode ser maior que 60 caracteres")
                .HasMaxLenght(x => x.Description, 200, "A descrição não pode ser maior que 200 caracteres");
        }
    }
}
