using FluentValidator;
using LuizaEMAPI.Domain.Commands.DepartmentCommand;
using LuizaEMAPI.Domain.Commands.Results;
using LuizaEMAPI.Domain.Commands.Shared;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Domain.Repositories;

namespace LuizaEMAPI.Domain.Commands.Handler
{
    public class DepartmentCommandHandler : Notifiable
    {

        private readonly IDepartmentRepository _repository;

        public DepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }        

        public ICommandResult Handler(CreateDepartmentCommand command)
        {
            //First - Department exist?
            if (_repository.DepartmentExists(command.Name))
            {
                AddNotification("Name", "Este departamento já existe");
                return null;
            }

            //Second - Create new Objetct Department
            Department depart = new Department(command.Name, command.Description, command.Active);

            AddNotifications(depart.Notifications);

            if (!depart.Valid)
                return null;

            _repository.Save(depart);

            return new DepartmentCommandResult(depart.Id, depart.Name);
        }

  
    }
}
