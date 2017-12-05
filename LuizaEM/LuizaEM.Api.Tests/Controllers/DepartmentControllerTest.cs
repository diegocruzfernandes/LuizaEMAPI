using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using LuizaEM.Domain.Services;

namespace LuizaEM.Api.Tests.Controllers
{
    [TestClass]
    public class DepartmentControllerTest
    {
        private readonly IDepartmentAppService _service;

        public DepartmentControllerTest(IDepartmentAppService service)
        {
            _service = service;

        }


        [TestMethod]
        public void TestMethod1()
        {
          
            var x = _service.Delete(1);

            
        }
    }
}
