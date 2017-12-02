using FluentValidator;
using LuizaEMAPI.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.AppService
{
    public class AppServiceBase : Notifiable
    {
        private IUow _uow;

        public AppServiceBase(IUow uow)
        {
            _uow = uow; 
        }
    }
}
