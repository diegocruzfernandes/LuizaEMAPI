using FluentValidator;
using LuizaEM.Domain.Services;
using System.Collections.Generic;
using LuizaEM.Domain.Commands.DepartmentCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Repositories;

namespace LuizaEM.AppService
{
    public class DepartmentAppService : Notifiable, IDepartmentAppService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentAppService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public Department Create(CreateDepartmentCommand command)
        {
            var depart = new Department(0, command.Name, command.Description, command.Active);

            if (_repository.DepartmentExists(command.Name))
                AddNotification("Department", "O Departamento já existe!");

            if (depart.IsValid())
                _repository.Save(depart);

            return depart;
        }

        public Department Get(int id)
        {
            var depart = _repository.Get(id);

            if (depart == null)
                AddNotification("Department", "Departamento não foi encontrado");

            return depart;
        }

        public IEnumerable<Department> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Department> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Department Update(EditDepartmentCommand command)
        {
            var depart = _repository.Get(command.Id);
            depart.UpdateData(command.Name, command.Description, command.Active);

            if (depart.IsValid())
                _repository.Update(depart);

            return depart;
        }

        public Department Delete(int id)
        {
            var depart = _repository.Get(id);

            if (depart == null)
                AddNotification("Department", "Não foi encontrado o departamento solicitado");
            else
                _repository.Delete(depart);

            return depart;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
