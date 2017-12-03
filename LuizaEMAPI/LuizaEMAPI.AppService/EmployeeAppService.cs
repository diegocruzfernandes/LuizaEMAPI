using LuizaEMAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Commands.EmployeeCommand;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Domain.Repositories;

namespace LuizaEMAPI.AppService
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeAppService(IEmployeeRepository repository)
        {
            _repository = repository;
        }


        public Employee Create(CreateEmployeeCommand command)
        {
            var employee = new Employee(command.FisrtName, command.LastName, command.Email, command.Department, command.BirthDate, command.Active);
            if (employee.Valid)
                _repository.Save(employee);

            return employee;
        }

        public Employee Delete(Guid id)
        {
            var employee = _repository.Get(id);

            if(employee == null)
                employee.AddNotification("Employee", "Não foi encontrado o empregado solicitado");
            else
                _repository.Delete(employee);

            return employee;
        }

        public IEnumerable<EmployeeCommand> Get()
        {
            return _repository.Get();
        }

        public Employee Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<EmployeeCommand> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Employee Update(EditEmployeeCommand command)
        {
            var employee = _repository.Get(command.Id);

            employee.ChangeFirstName(command.FisrtName);
            employee.ChangeLastName(command.LastName);
            employee.ChangeEmail(command.Email);
            employee.ChangeDepartment(command.Department);
            employee.ChangeBirthDate(command.BirthDate);
            if (command.Active) employee.Activate(); else employee.Deactivate();

            if (employee.Valid)
                _repository.Update(employee);

            return employee;
        }
    }
}
