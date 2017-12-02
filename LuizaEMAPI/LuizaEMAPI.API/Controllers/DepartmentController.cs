using LuizaEMAPI.Domain.Commands.Handler;
using LuizaEMAPI.Domain.Commands.Inputs;
using LuizaEMAPI.Domain.Repositories;
using LuizaEMAPI.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEMAPI.API.Controllers
{

    public class DepartmentController : BaseController
    {
       
        private readonly IDepartmentRepository _repository;
        private readonly DepartmentCommandHandler _handler;

        public DepartmentController(DepartmentCommandHandler handler, IDepartmentRepository repository, IUow uow) : base(uow)
        {
            _repository = repository;
            _handler = handler;
         
        }

        [HttpGet]
        [Route("v1/department")]
        public async Task<IActionResult> Get()
        {
            var result = _repository.Get();
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/department/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpDelete]
        [Route("v1/department/{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_repository.Get(id));
        }



        [HttpPost]
        [Route("v1/department")]
        public async Task<IActionResult> Post([FromBody]DepartmentCommand command)
        {
            var result = _handler.Handler(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
