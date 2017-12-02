using FluentValidator;
using LuizaEMAPI.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaEMAPI.API.Controllers
{
    public class BaseController : Controller
    {

        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    //Create the LOG FILE
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma folha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }

        public async Task<IActionResult> ResponseList(object result)
        {
            try
            {
                return Ok(result);
            }
            catch
            {
                //Create the LOG FILE
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "Ocorreu uma folha interna no servidor." }
                });
            }

        }
    }
}
