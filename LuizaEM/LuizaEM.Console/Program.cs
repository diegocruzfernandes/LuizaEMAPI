using LuizaEM.Domain.Entities;
using LuizaEM.Infra.Context;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.ViewConsole
{
    class Program
    {
      
        static void Main(string[] args)
        {
            var contexto = new DataContext();

            var lista = contexto.Employees.Include(d => d.Department).ToList();

            foreach (var item in lista)
            {
                Console.WriteLine($"Name:{item.FirstName} - {item.Department.Name}");
            }
            /*
            var dept = new Department(0, "segurança", "cao segurança", true);
            var emp = new Employee(0, "sofia", "Diniz", "sofia@mail.com", 3, new DateTime(2010, 06, 15), true);

            //contexto.Departments.Add(dept);
            // contexto.Employees.Add(emp);
            Console.WriteLine("Criada as instâncias");

            try
            {
                contexto.SaveChanges();
                Console.WriteLine("Terminado com sucesso...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            */
            Console.ReadKey();
        }

        public static void View()
        {
            
        }
    }
}
