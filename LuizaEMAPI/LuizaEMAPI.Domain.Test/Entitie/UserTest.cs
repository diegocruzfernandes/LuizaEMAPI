using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEMAPI.Domain.Entities;
using LuizaEMAPI.Domain.Common;

namespace LuizaEMAPI.Domain.Test.Entitie
{
    [TestClass]
    public class UserTest
    {
        private string Name = "John Carter";
        private string Email = "teste@email.com";
        private string Password = "123456";
        private EPermission Permission = EPermission.Default;



        [TestMethod]
        [TestCategory("User")]
        public void CreateObjectNewUser()
        {
            User user = new User(Name, Email, Password, Permission, true);
            Assert.IsTrue(user.Valid);
        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidNameShouldReturnNotification()
        {
            //Dont empty
            User user = new User("", Email, Password, Permission, true);
            Assert.IsFalse(user.Valid);

            //lenght < 3
            User user2 = new User("Jo", Email, Password, Permission, true);
            Assert.IsFalse(user2.Valid);

            //lenght > 50
            User user3 = new User("John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", Email, Password, Permission, true);
            Assert.IsFalse(user3.Valid);

       
        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {

            //Invalid format
            User user = new User(Name, "meuemail", Password, Permission, true);
            Assert.IsFalse(user.Valid);

            //Dont empty
            User user2 = new User(Name, "", Password, Permission, true);
            Assert.IsFalse(user2.Valid);

            //Min lenght = 10
            User user3 = new User(Name, "me", Password, Permission, true);
            Assert.IsFalse(user3.Valid);

            //Max lenght = 50
            User user4 = new User(Name, "meuemailestacomvalormaiorque50caracteres@provedor.com", Password, Permission, true);
            Assert.IsFalse(user4.Valid);
        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidPasswordShouldReturnNotification()
        {
            //is not null or empty
            User user = new User(Name, Email, "", Permission, true);
            Assert.IsFalse(user.Valid);

            //lenght < 3
            User user2 = new User(Name, Email, "ab", Permission, true);
            Assert.IsFalse(user2.Valid);

            //lenght > 60
            User user3 = new User(Name, Email, "Pneumoultramicroscopicossilicovulcanoconiotico_Inconstitucionalissimo", Permission, true);
            Assert.IsFalse(user3.Valid);
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeAnInvalidEmaildShouldReturnNotification()
        {
            //is not null or empty

            //lenght > 10
            User user = new User(Name, Email, Password, Permission, true);
            user.ChangeEmail("email");
            Assert.IsFalse(user.Valid);

            User user2 = new User(Name, Email, Password, Permission, true);
            user2.ChangeEmail("teste_mail.com.br");
            Assert.IsFalse(user2.Valid);

            User user3 = new User(Name, Email, Password, Permission, true);
            user3.ChangeEmail("meuemailestacomvalormaiorque50caracteres@provedor.com");
            Assert.IsFalse(user3.Valid);

        }

        [TestMethod]
        [TestCategory("User")]
        public void ValidationPasswordValue()
        {
            User user = new User(Name, Email, Password, Permission, true);
            Assert.AreEqual(user.Password, ValidationPassword.Encrypt(Password));

            user.ResetPassword();
            Assert.AreNotEqual(user.Password, ValidationPassword.Encrypt(Password));
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeActivationUser()
        {
            User user = new User(Name, Email, Password, Permission, true);
            Assert.IsTrue(user.Active);

            user.Deactivate();
            Assert.IsFalse(user.Active);
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeName()
        {
            User user = new User(Name, Email, Password, Permission, true);

            user.ChangeName("John Gabriel");

            Assert.AreNotEqual(user.Name, Name);
            Assert.IsTrue(user.Active);
        }

        [TestMethod]
        [TestCategory("User")]
        public void AuthenticateValidation()
        {
            User user = new User(Name, Email, Password, Permission, true);

            var result = user.Authenticate(Email, Password);
            Assert.IsTrue(result);
        }
    }
}
