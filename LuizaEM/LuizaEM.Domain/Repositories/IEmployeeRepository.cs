using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Entities;
using System.Collections.Generic;

namespace LuizaEM.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeCommand> Get();
        IEnumerable<Employee> Get(int skip, int take);
        IEnumerable<Employee> Find(string firstname, string lastname, bool match);
        Employee Get(int id);
        void Save(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        bool EmployeeExists(Employee employee);
    }
}
