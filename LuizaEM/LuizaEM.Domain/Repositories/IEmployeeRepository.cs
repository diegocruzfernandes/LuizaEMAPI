using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeCommand> Get();
        IEnumerable<EmployeeCommand> Get(int skip, int take);
        Employee Get(int id);
        Employee GetByName(string firstname);
        void Save(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        bool EmployeeExists(Employee employee);
    }
}
