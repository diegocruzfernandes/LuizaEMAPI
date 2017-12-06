using LuizaEM.Domain.Commands.DepartmentCommands;
using LuizaEM.Domain.Entities;
using System.Collections.Generic;

namespace LuizaEM.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Get();
        IEnumerable<Department> Get(int skip, int take);
        Department Get(int id);
        Department GetByName(string name);
        void Save(Department depart);
        void Update(Department depart);
        void Delete(Department depart);
        bool DepartmentExists(string name);
    }
}
