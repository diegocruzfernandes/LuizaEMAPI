using LuizaEMAPI.Domain.Commands.EmployeeCommand;
using LuizaEMAPI.Domain.Services;
using LuizaEMAPI.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEMAPI.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeAppService _service;

        public EmployeeController(IEmployeeAppService service, IUow uow) :  base(uow)
        {
            _service = service;
        }

        [HttpGet]
        [Route("v1/employee")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }

        //TODO: Resolver
        [HttpGet]
        [Route("v1/employee/Page={skip:int:min(0)},Page_Size={take:int:min(1)}")]
        public async Task<IActionResult> GetByRange(int skip, int take)
        {
            var result = _service.Get(skip, take);
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/employee/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_service.Get(id));
        }

        [HttpDelete]
        [Route("v1/employee/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _service.Delete(id);
            return await Response(result, result.Notifications);
        }

        [HttpPost]
        [Route("v1/employee")]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand command)
        {
            var result = _service.Create(command);
            return await Response(result, result.Notifications);
        }

        [HttpPut]
        [Route("v1/employee")]
        public async Task<IActionResult> Update([FromBody] EditEmployeeCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, result.Notifications);

        }
    }
}
