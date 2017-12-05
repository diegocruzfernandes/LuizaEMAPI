using FluentValidator;
using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Domain.Services
{
    public interface IEmployeeAppService
    {
        IEnumerable<EmployeeCommand> Get();
        IEnumerable<ViewSimpleEmployeeCommand> GetSimpleInformation(int skip, int take);
        IEnumerable<ViewCompleteEmployeeCommand> GetFullInformation(int skip, int take);
        IEnumerable<ViewCompleteEmployeeCommand> Find(string firstname, string lastname, bool match);
        Employee Get(int id);
        Employee Create(CreateEmployeeCommand command);
        Employee Update(EditEmployeeCommand command);
        Employee Delete(int id);
        IEnumerable<Notification> Validate();
    }
}
