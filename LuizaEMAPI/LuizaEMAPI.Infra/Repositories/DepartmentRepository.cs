using LuizaEMAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Contexts;
using LuizaEMAPI.Domain.Commands.Handler;
using LuizaEMAPI.Domain.Commands.Inputs;

namespace LuizaEMAPI.Infra.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly LuizaEMAPIDataContext _context;

        public DepartmentRepository(LuizaEMAPIDataContext context)
        {
            _context = context;
        }

        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(x => x.Name == name);
        }

        public IEnumerable<DepartmentCommand> Get()
        {
            return _context
                .Departments
                .Select(x => new DepartmentCommand
                {
                    Name = x.Name.ToString(),
                    Description = x.Description.ToString(),
                    Active = x.Active
                })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Department Get(Guid id)
        {
           return _context.Departments.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Department GetByName(string name)
        {
           return _context.Departments.AsNoTracking().FirstOrDefault(x => x.Name == name);
        }

        public void Save(Department depart)
        {
            _context.Departments.Add(depart);           
        }

        public void Update(Department depart)
        {
            _context.Entry(depart).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
