using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaEMAPI.Domain.Common
{
    public enum EPermission
    {
        Admin = 0,
        Maintenace = 1,
        Manager = 2,
        Default = 3,
        Guest = 4
    }
}
