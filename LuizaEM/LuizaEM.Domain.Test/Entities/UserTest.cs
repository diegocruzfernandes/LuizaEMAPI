using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEM.Domain.Shared;
using LuizaEM.Domain.Entities;

namespace LuizaEM.Domain.Tests.Entities
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
        public void CreateNewInstanceUser()
        {
            User user = new User(0, Name, Email, Password, Permission, true);
            Assert.IsTrue(user.IsValid());
        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidNameShouldReturnNotification()
        {
            //Dont empty
            User user = new User(0, "", Email, Password, Permission, true);
            Assert.IsFalse(user.IsValid());

            //lenght < 3
            User user2 = new User(0, "Jo", Email, Password, Permission, true);
            Assert.IsFalse(user2.IsValid());

            //lenght > 50
            User user3 = new User(0, "John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", Email, Password, Permission, true);
            Assert.IsFalse(user3.IsValid());


        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            //Invalid format
            User user = new User(0, Name, "meuemail", Password, Permission, true);
            Assert.IsFalse(user.IsValid());

            //Dont empty
            User user2 = new User(0, Name, "", Password, Permission, true);
            Assert.IsFalse(user2.IsValid());

            //length > 3
            User user3 = new User(0, Name, "me", Password, Permission, true);
            Assert.IsFalse(user3.IsValid());

            //length < 50
            User user4 = new User(0, Name, "meuemailnaodeveestacomvaloresmaiorque60caracteres@provedor.com", Password, Permission, true);
            Assert.IsFalse(user4.IsValid());
        }

        [TestMethod]
        [TestCategory("User")]
        public void GivenAnInvalidPasswordShouldReturnNotification()
        {
            //is not null or empty
            User user = new User(0, Name, Email, "", Permission, true);
            Assert.IsFalse(user.IsValid());

            //length < 3
            User user2 = new User(0, Name, Email, "ab", Permission, true);
            Assert.IsFalse(user2.IsValid());

            //length > 60
            User user3 = new User(0, Name, Email, "Pneumoultramicroscopicossilicovulcanoconiotico_Inconstitucionalissimo", Permission, true);
            Assert.IsFalse(user3.IsValid());
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeAnInvalidEmaildShouldReturnNotification()
        {
            //is not null or empty

            //length > 10
            User user = new User(0, Name, Email, Password, Permission, true);
            user.ChangeEmail("email");
            Assert.IsFalse(user.IsValid());

            //format invalid
            User user2 = new User(0, Name, Email, Password, Permission, true);
            user2.ChangeEmail("teste_mail.com.br");
            Assert.IsFalse(user2.IsValid());

            //length < 50
            User user3 = new User(0, Name, Email, Password, Permission, true);
            user3.ChangeEmail("meuemailnaodeveestacomvaloresmaiorque60caracteres@provedor.com");
            Assert.IsFalse(user3.IsValid());

        }

        [TestMethod]
        [TestCategory("User")]
        public void ValidationPasswordValueCompareNewWithOld()
        {
            User user = new User(0, Name, Email, Password, Permission, true);
            Assert.AreEqual(user.Password, ValidationPassword.Encrypt(Password));

            user.ResetPassword();
            Assert.AreNotEqual(user.Password, ValidationPassword.Encrypt(Password));
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeActivationUser()
        {
            User user = new User(0, Name, Email, Password, Permission, true);
            Assert.IsTrue(user.Active);

            user.Deactivate();
            Assert.IsFalse(user.Active);
        }

        [TestMethod]
        [TestCategory("User")]
        public void ChangeNameCompareNewWithOld()
        {
            User user = new User(0, Name, Email, Password, Permission, true);

            user.ChangeUserName("John Gabriel");
            
            Assert.AreNotEqual(user.Username, Name);
            Assert.IsTrue(user.Active);
        }

        [TestMethod]
        [TestCategory("User")]
        public void AuthenticateValidation()
        {
            User user = new User(0, Name, Email, Password, Permission, true);

            var result = user.Authenticate(Email, Password);
            Assert.IsTrue(result);
        }
    }
}
