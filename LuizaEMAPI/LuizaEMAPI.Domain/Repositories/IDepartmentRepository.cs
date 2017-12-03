using LuizaEMAPI.Domain.Commands.DepartmentCommand;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LuizaEMAPI.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentCommand> Get();
        IEnumerable<DepartmentCommand> Get(int skip, int take);
        Department Get(Guid id);
        Department GetByName(string name);
        void Save(Department depart);
        void Update(Department depart);
        void Delete(Department depart);
        bool DepartmentExists(string name);
    }
}
