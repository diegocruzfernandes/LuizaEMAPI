using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Common
{
    public class Entity : Notifiable
    {
        public Guid Id { get; private set; }
    }
}
