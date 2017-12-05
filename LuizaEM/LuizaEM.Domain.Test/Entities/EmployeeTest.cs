using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEM.Domain.Entities;

namespace LuizaEM.Domain.Tests.Entities
{
    [TestClass]
    public class EmployeeTest
    {
        private string FirstName = "John";
        private string LastName = "Carter";
        private string Email = "johncarter@mail.com";
        private int DepartId = 5;
        private Department Depart = new Department(5, "Administration", "Manager", true);
        private DateTime BirthDate = new DateTime(1986, 6, 21);

        [TestMethod]
        [TestCategory("Employee")]
        public void CreateNewInstanceEmployee()
        {
            Employee employee = new Employee(0, FirstName, LastName, Email, DepartId, BirthDate, true);
            Assert.IsTrue(employee.IsValid());
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidFirstNameShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee(0, "", LastName, Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee.IsValid());

            //length > 3
            Employee employee2 = new Employee(0, "Jo", LastName, Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee2.IsValid());

            //length < 50
            Employee employee3 = new Employee(0, "John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", LastName, Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee3.IsValid());

        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidLastNameShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee(0, FirstName, "", Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee.IsValid());

            //length > 3
            Employee employee2 = new Employee(0, FirstName, "Ca", Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee2.IsValid());

            //length < 60
            Employee employee3 = new Employee(0, FirstName, "John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", Email, DepartId, BirthDate, true);
            Assert.IsFalse(employee3.IsValid());
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee(0, FirstName, LastName, "", DepartId, BirthDate, true);
            Assert.IsFalse(employee.IsValid());

            //length > 10
            Employee employee2 = new Employee(0, FirstName, LastName, "jo@em.co", DepartId, BirthDate, true);
            Assert.IsFalse(employee2.IsValid());

            //format invalid
            Employee employee3 = new Employee(0, FirstName, LastName, "john_email.co", DepartId, BirthDate, true);
            Assert.IsFalse(employee3.IsValid());

            //length < 60
            Employee employee4 = new Employee(0, FirstName, LastName, "meuemailnaodeveestacomvaloresmaiorque60caracteres@provedor.com", DepartId, BirthDate, true);
            Assert.IsFalse(employee4.IsValid());
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ShouldReturnFullNameNotification()
        {
            Employee employee = new Employee(0, FirstName, LastName, Email, DepartId, BirthDate, true);

            var FullName = employee.FullName();

            var MockFullName = $"{FirstName} {LastName}";

            Assert.AreEqual(FullName, MockFullName);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void UpdateDateCompareNewWithOld()
        {
            Employee employee = new Employee(0, FirstName, LastName, Email, DepartId, BirthDate, true);

            employee.UpdateData("Michael", "Stark", "michael@mail.com", 9, new DateTime(1987, 5, 22), false);

            Assert.AreNotEqual(employee.FirstName, FirstName);
            Assert.AreNotEqual(employee.LastName, LastName);
            Assert.AreNotEqual(employee.Email, Email);
            Assert.AreNotEqual(employee.DepartmentId, DepartId);
            Assert.AreNotEqual(employee.BirthDate, BirthDate);
            Assert.IsFalse(employee.Active);            
            
            Assert.IsTrue(employee.IsValid());
        }
       

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeActivationEmployee()
        {
            Employee employee = new Employee(0, FirstName, LastName, Email, DepartId, BirthDate, true);
            Assert.IsTrue(employee.Active);

            employee.Deactivate();
            Assert.IsFalse(employee.Active);
        }

    }
}
