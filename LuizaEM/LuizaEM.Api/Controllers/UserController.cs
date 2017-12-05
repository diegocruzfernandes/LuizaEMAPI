using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Services;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEM.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAppService _service;

        public UserController(IUserAppService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
                return await ResponseNullOrEmpty();

            var result = _service.Create(command);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/user")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }


        [HttpGet]
        [Route("v1/user/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/user/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/user")]
        public async Task<IActionResult> Update([FromBody] EditUserCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/user/{id}/reset")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var result = _service.ResetPassword(id);
            return await Response(result, _service.Validate());
        }
    }
}
