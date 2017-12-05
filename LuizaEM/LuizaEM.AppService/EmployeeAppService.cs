using FluentValidator;
using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Repositories;
using LuizaEM.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.AppService
{
    public class EmployeeAppService : Notifiable, IEmployeeAppService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _repositoryDepart;
        public EmployeeAppService(IEmployeeRepository repository, IDepartmentRepository repositoryDepart)
        {
            _repository = repository;
            _repositoryDepart = repositoryDepart;
        }


        public Employee Create(CreateEmployeeCommand command)
        {

            var department = _repositoryDepart.Get(command.DepartmentId);

            var employee = new Employee(0, command.FirstName, command.LastName, command.Email, command.DepartmentId, command.BirthDate, command.Active);

            if (department == null)
                AddNotification("Employee", "Não foi encontrado o departamento indicado");

            if (employee.IsValid())
                _repository.Save(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _repository.Get(id);

            if (employee == null)
                AddNotification("Employee", "Não foi encontrado o empregado solicitado");
            else
                _repository.Delete(employee);

            return employee;
        }

        public IEnumerable<EmployeeCommand> Get()
        {
            return _repository.Get();
        }

        public Employee Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<EmployeeCommand> GetFullInformation(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public IEnumerable<ViewSimpleEmployeeCommand> GetSimpleInformation(int skip, int take)
        {
            var listEmployees = _repository.Get(skip, take);

            List<ViewSimpleEmployeeCommand> simpleListEmployees = null;
            foreach (var employee in listEmployees)
            {
                simpleListEmployees.Add(new ViewSimpleEmployeeCommand(employee.FullName(), employee.Email, employee.Department));
            }

            return simpleListEmployees;
        }



        public Employee Update(EditEmployeeCommand command)
        {
            var employee = _repository.Get(command.Id);

            employee.UpdateData(command.FirstName, command.LastName, command.Email, command.DepartmentId, command.BirthDate, command.Active);
                      
            if (employee.IsValid())
                _repository.Update(employee);

            return employee;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
