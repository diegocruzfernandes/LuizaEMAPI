using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEM.Domain.Shared;

namespace LuizaEM.Domain.Test.Shared
{
    [TestClass]
    public class ValidationPasswordTest
    {
        [TestMethod]
        [TestCategory("Password")]
        public void GivenAnStringReturnValueEncripty()
        {
            var password = "mypass";
            var password_encripted = ValidationPassword.Encrypt(password);
            Assert.AreNotEqual(password, password_encripted);
        }
    }
}
