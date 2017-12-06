using LuizaEM.Domain.Commands.DepartmentCommands;
using LuizaEM.Domain.Services;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LuizaEM.Api.Controllers
{
    public class DepartmentController : BaseController
    {

        private readonly IDepartmentAppService _service;

        public DepartmentController(IDepartmentAppService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpGet]
        [Route("v1/department/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet]
        [Route("v1/departments")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/department")]
        public async Task<IActionResult> GetByRange(
            [FromQuery(Name = "page_size")]int page_size,
            [FromQuery(Name = "page")]int page)
        {
            var skip = (page - 1) * page_size;

            var result = _service.Get(skip, page_size);
            return await ResponseList(result);
        }

     
        [HttpDelete]
        [Route("v1/department/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, result.Notifications);
        }

        [HttpPost]
        [Route("v1/department")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand command)
        {
            var result = _service.Create(command);
            return await Response(result, result.Notifications);
        }

        [HttpPut]
        [Route("v1/department")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] EditDepartmentCommand command)
        {
            var result = _service.Update(command);
            return await Response(result, result.Notifications);

        }
    }
}
