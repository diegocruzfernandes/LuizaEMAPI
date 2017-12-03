using LuizaEMAPI.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEMAPI.API.Controllers
{
    public class UserController : BaseController
    {

        public UserController(IUow uow) : base(uow) 
        {

        }


        /*
        [HttpPost]
        [Route("v1/user")]
        public IActionResult CreateUser([FromBody] )
        {

        }
        */}
}
