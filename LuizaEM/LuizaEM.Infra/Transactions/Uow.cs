using LuizaEM.Infra.Context;

namespace LuizaEM.Infra.Transactions
{

   
    public class Uow : IUow
    {
        private readonly DataContext _context;

        public Uow(DataContext context)
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
