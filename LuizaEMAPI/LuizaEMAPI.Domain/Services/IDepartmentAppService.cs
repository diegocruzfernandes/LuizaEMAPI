using LuizaEMAPI.Domain.Commands.DepartmentCommand;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Services
{
    public interface IDepartmentAppService
    {
        IEnumerable<DepartmentCommand> Get();
        IEnumerable<DepartmentCommand> Get(int skip, int take);
        Department Get(Guid id);
        Department Create(CreateDepartmentCommand command);
        Department Update(EditDepartmentCommand command);
        Department Delete(Guid id);

    }
}
