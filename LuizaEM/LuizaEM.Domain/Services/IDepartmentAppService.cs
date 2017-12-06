using FluentValidator;
using LuizaEM.Domain.Commands.DepartmentCommands;
using LuizaEM.Domain.Entities;
using System.Collections.Generic;

namespace LuizaEM.Domain.Services
{
    public interface IDepartmentAppService
    {   
        IEnumerable<Department> Get();
        IEnumerable<Department> Get(int skip, int take);
        Department Get(int id);
        Department Create(CreateDepartmentCommand command);
        Department Update(EditDepartmentCommand command);
        Department Delete(int id);
        IEnumerable<Notification> Validate();

    }
}
