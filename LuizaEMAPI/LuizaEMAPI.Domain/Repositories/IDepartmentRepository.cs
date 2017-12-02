using LuizaEMAPI.Domain.Commands.Inputs;
using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LuizaEMAPI.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentCommand> Get();
        Department Get(Guid id);
        Department GetByName(string name);
        void Save(Department depart);
        void Update(Department depart);
        bool DepartmentExists(string name);
    }
}
