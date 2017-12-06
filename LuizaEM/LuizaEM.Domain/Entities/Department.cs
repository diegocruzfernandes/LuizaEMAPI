using FluentValidator;

namespace LuizaEM.Domain.Entities
{
    public class Department : Notifiable
    {
        #region Constructor
        protected Department() { }

        public Department(int id, string name, string description, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;

            Validate();
        }
        #endregion

        #region Attribute
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region Methods
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
                .IsRequired(x => x.Name)
                .HasMinLenght(x => x.Name, 3, "O  nome não pode ser menor que 3 caracteres")
                .HasMaxLenght(x => x.Name, 60, "O  nome não pode ser maior que 60 caracteres")
                .HasMaxLenght(x => x.Description, 200, "A descrição não pode ser maior que 200 caracteres");
        }
        #endregion
    }
}
