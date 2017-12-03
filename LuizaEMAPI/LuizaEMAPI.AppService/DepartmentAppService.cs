using LuizaEMAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Commands.DepartmentCommand;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Domain.Repositories;
using FluentValidator;

namespace LuizaEMAPI.AppService
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
            var depart = new Department(command.Name, command.Description, command.Active);

            if (depart.Valid)
                _repository.Save(depart);

            return depart;
        }



        public Department Get(Guid id)
        {
            var depart = _repository.Get(id);

            if (depart == null)
                depart.AddNotification("Department", "Nada foi encontrado");

            return depart;
        }

        public IEnumerable<DepartmentCommand> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<DepartmentCommand> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Department Update(EditDepartmentCommand command)
        {
            var depart = _repository.Get(command.Id);

            depart.ChangeName(command.Name);
            depart.ChangeDescription(command.Description);
            if (command.Active) depart.Activate(); else depart.Deactivate();

            if (depart.Valid)
                _repository.Update(depart);

            return depart;
        }

        public Department Delete(Guid id)
        {
            var depart = _repository.Get(id);

            if (depart == null)
                depart.AddNotification("Department", "Não foi encontrado o departamento solicitado");
            else
                _repository.Delete(depart);

            return depart;
        }
    }
}
