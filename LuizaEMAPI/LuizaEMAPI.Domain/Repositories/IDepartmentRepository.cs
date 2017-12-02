using LuizaEMAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Department Get(Guid id);
        Department GetByName(string name);
        void Save(Department depart);
        void Update(Department depart);
    }
}
