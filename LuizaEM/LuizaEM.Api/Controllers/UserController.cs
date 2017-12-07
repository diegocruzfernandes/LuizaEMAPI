using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Services;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
                return await ResponseNullOrEmpty();

            var result = _service.Create(command);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/users")]
        public async Task<IActionResult> Get([FromQuery(Name = "full")]bool full)
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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/user")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] EditUserCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/user/{id}/resetpass")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var result = _service.ResetPassword(id);
            return await Response(result, _service.Validate());
        }
    }
}
