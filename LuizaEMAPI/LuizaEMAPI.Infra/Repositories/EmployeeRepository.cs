using LuizaEMAPI.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Infra.Contexts;
using LuizaEMAPI.Domain.Commands.EmployeeCommand;

namespace LuizaEMAPI.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //video 14 - 6:30min
        private readonly LuizaEMAPIDataContext _context;

        public EmployeeRepository(LuizaEMAPIDataContext context)
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
                .Select(e => new EmployeeCommand
                {
                    FisrtName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Department = e.Department,
                    BirthDate = e.BirthDate,
                    Active = e.Active
                })
            .OrderBy(e => e.FisrtName)
            .ToList();
        }

        public Employee Get(Guid id)
        {
            return _context.Employees.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EmployeeCommand> Get(int skip, int take)
        {
            return _context
               .Employees
               .Select(e => new EmployeeCommand
               {
                   FisrtName = e.FirstName,
                   LastName = e.LastName,
                   Email = e.Email,
                   Department = e.Department,
                   BirthDate = e.BirthDate,
                   Active = e.Active
               })
               .OrderBy(e => e.FisrtName)
               .Skip(skip)
               .Take(take)
               .ToList();
        }

        public Employee GetByName(string firstname)
        {
            return _context.Employees.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.FirstName == firstname);
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
