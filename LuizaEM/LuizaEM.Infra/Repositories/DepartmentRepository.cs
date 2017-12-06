using LuizaEM.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using LuizaEM.Domain.Entities;
using LuizaEM.Infra.Context;

namespace LuizaEM.Infra.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(x => x.Name == name);
        }

        public IEnumerable<Department> Get()
        {
            return _context
                 .Departments
                 .OrderBy(x => x.Name)
                 .ToList();
        }

        public Department Get(int id)
        {
            return _context.Departments.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Department> Get(int skip, int take)
        {
            return _context
               .Departments
               .OrderBy(x => x.Name)
               .Skip(skip)
               .Take(take)
               .ToList();
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

        public void Delete(Department depart)
        {
            _context.Entry(depart).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
