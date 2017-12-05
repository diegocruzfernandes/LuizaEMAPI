using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEM.Infra.Transactions
{
    /// <summary>
    /// Unit of Work Transaction for commit in DB
    /// </summary>
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
