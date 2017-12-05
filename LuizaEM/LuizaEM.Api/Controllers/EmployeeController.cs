using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Services;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEM.Api.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeAppService _service;

        public EmployeeController(IEmployeeAppService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        /*
        [HttpGet]
        [Route("v1/employee")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }
        */

        
        [HttpGet]
        [Route("v1/employee")]
        public async Task<IActionResult> GetByRange([FromQuery(Name="page_size")]int page_size, [FromQuery(Name="page")]int page)
        {
            if (page_size > 0 && page > -1)
            {
                var pageskip = page_size * page;
                var result = _service.GetSimpleInformation(pageskip, page_size);
                return await ResponseList(result);
            }
            else
            {
                var result = _service.Get();
                return await ResponseList(result);
            }
        }

        [HttpGet]
        [Route("v1/employee/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpDelete]
        [Route("v1/employee/{id}")]
        public async Task<IActionResult> Delete(int id)
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
