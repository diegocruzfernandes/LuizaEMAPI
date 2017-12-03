using LuizaEMAPI.Domain.Commands.UserCommand;
using LuizaEMAPI.Domain.Services;
using LuizaEMAPI.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEMAPI.API.Controllers
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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
                return await ResponseNullOrEmpty();

            var result = _service.Create(command);
            return await Response(result, result.Notifications);
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
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/user/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _service.Delete(id);
            return await Response(result, result.Notifications);
        }

        [HttpPut]
        [Route("v1/user")]
        public async Task<IActionResult> Update([FromBody] EditUserCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, result.Notifications);

        }
    }
}
