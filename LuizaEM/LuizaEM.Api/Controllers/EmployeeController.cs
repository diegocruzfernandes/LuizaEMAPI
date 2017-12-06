using LuizaEM.Domain.Commands.EmployeeCommands;
using LuizaEM.Domain.Services;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("v1/employee")]
        public async Task<IActionResult> GetByRange(
            [FromQuery(Name = "page_size")]int page_size,
            [FromQuery(Name = "page")]int page,
            [FromQuery(Name = "full")]bool full)
        {
               var skip = (page - 1) * page_size;

                if (full)
                {
                    var result = _service.GetFullInformation(skip, page_size);
                    return await ResponseList(result);
                }
                else
                {
                    var result = _service.GetSimpleInformation(skip, page_size);
                    return await ResponseList(result);
                }
        }

        [HttpGet]
        [Route("v1/employee/find")]
        public async Task<IActionResult> Find(
           [FromQuery(Name = "firstname")]string firstname,
           [FromQuery(Name = "lastname")]string lastname,
           [FromQuery(Name = "match")]bool match)
        {
            var result = _service.Find(firstname, lastname, match);
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/employee/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpDelete]
        [Route("v1/employee/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, result.Notifications);
        }

        [HttpPost]
        [Route("v1/employee")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand command)
        {
            var result = _service.Create(command);
            return await Response(result, result.Notifications);
        }

        [HttpPut]
        [Route("v1/employee")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] EditEmployeeCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, result.Notifications);

        }
    }
}
