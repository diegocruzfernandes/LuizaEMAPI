using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Repositories;
using LuizaEM.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {     
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Deleted;
        }

        public bool EmployeeExists(Employee employee)
        {
            return _context.Employees.Any(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName);
        }

        public IEnumerable<EmployeeCommand> Get()
        {
            return _context
                .Employees
                .Include(x => x.Department)
                .Select(e => new EmployeeCommand
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    DepartmentId = e.DepartmentId,
                    Department = e.Department.Name,
                    BirthDate = e.BirthDate,
                    Active = e.Active
                })
            .OrderBy(e => e.FirstName)
            .ToList();
        }

        public Employee Get(int id)
        {
            return _context.Employees.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> Get(int skip, int take)
        {
            return _context
               .Employees
               .Include(x => x.Department)
               .OrderBy(e => e.FirstName)
               .Skip(skip)
               .Take(take)
               .ToList();
        }

        public IEnumerable<Employee> Find(string firstname, string lastname, bool match)
        {
            string find = "";

            if (string.IsNullOrEmpty(lastname))
                return _context.Employees.Include(x => x.Department).AsNoTracking().Where(x => x.FirstName.Contains(firstname));            

            if (string.IsNullOrEmpty(firstname))
                return _context.Employees.Include(x => x.Department).AsNoTracking().Where(x => x.LastName.Contains(lastname));

            if (match && find == "")
                return _context.Employees.Include(x => x.Department).AsNoTracking().Where(x => x.FirstName.Contains(firstname) || x.LastName.Contains(lastname));
            else
                return _context.Employees.Include(x => x.Department).AsNoTracking().Where(x => x.FirstName.Contains(firstname) && x.LastName.Contains(lastname));
        }

        public void Save(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
