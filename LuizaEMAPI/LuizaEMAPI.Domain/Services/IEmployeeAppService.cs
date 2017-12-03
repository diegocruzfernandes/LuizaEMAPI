using LuizaEMAPI.Domain.Commands.EmployeeCommand;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Services
{
    public interface IEmployeeAppService
    {
        IEnumerable<EmployeeCommand> Get();
        IEnumerable<EmployeeCommand> Get(int skip, int take);
        Employee Get(Guid id);
        Employee Create(CreateEmployeeCommand command);
        Employee Update(EditEmployeeCommand command);
        Employee Delete(Guid id);
    }
}
