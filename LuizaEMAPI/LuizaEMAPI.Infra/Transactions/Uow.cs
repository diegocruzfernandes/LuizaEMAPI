using LuizaEMAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly LuizaEMAPIDataContext _context;

        public Uow(LuizaEMAPIDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
           //Nothing... the EF dead de transaction; 
        }
    }
}
