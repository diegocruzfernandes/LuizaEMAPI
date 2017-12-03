using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEMAPI.Domain.Entities;

namespace LuizaEMAPI.Domain.Test.Entitie
{
    [TestClass]
    public class EmployeeTest
    {
        private string FirstName = "John";
        private string LastName = "Carter";
        private string Email = "johncarter@mail.com";
        private Department Depart = new Department("Administration", "Manager", true);
        private DateTime BirthDate = new DateTime(1986, 6, 21);

        [TestMethod]
        [TestCategory("Employee")]
        public void CreateNewInstanceEmployee()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidFirstNameShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee("", LastName, Email, Depart, BirthDate, true);
            Assert.IsFalse(employee.Valid);

            //length > 3
            Employee employee2 = new Employee("Jo", LastName, Email, Depart, BirthDate, true);
            Assert.IsFalse(employee2.Valid);

            //length < 50
            Employee employee3 = new Employee("John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", LastName, Email, Depart, BirthDate, true);
            Assert.IsFalse(employee3.Valid);
            
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidLastNameShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee(FirstName, "", Email, Depart, BirthDate, true);
            Assert.IsFalse(employee.Valid);

            //length > 3
            Employee employee2 = new Employee(FirstName, "Ca", Email, Depart, BirthDate, true);
            Assert.IsFalse(employee2.Valid);

            //length < 60
            Employee employee3 = new Employee(FirstName, "John Carter Kenmisubeth Fortintineancar Mashephialin Sutariala", Email, Depart, BirthDate, true);
            Assert.IsFalse(employee3.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            //don't empty
            Employee employee = new Employee(FirstName, LastName, "", Depart, BirthDate, true);
            Assert.IsFalse(employee.Valid);

            //length > 10
            Employee employee2 = new Employee(FirstName, LastName, "jo@em.co", Depart, BirthDate, true);
            Assert.IsFalse(employee2.Valid);

            //format invalid
            Employee employee3 = new Employee(FirstName, LastName, "john_email.co", Depart, BirthDate, true);
            Assert.IsFalse(employee3.Valid);

            //length < 50
            Employee employee4 = new Employee(FirstName, LastName, "meuemailestacomvalormaiorque50caracteres@provedor.com", Depart, BirthDate, true);
            Assert.IsFalse(employee4.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ShouldReturnFullNameNotification()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);

            var FullName = employee.FullName();

            var MockFullName = $"{FirstName} {LastName}";

            Assert.AreEqual(FullName, MockFullName);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeAnFirstNameCompareNewWithOld()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            employee.ChangeFirstName("Michael");

            Assert.AreNotEqual(employee.FirstName, FirstName);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeAnLastNameCompareNewWithOld()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            employee.ChangeLastName("Stark");

            Assert.AreNotEqual(employee.LastName, LastName);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeAnEmailCompareNewWithOld()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            employee.ChangeEmail("michael@mail.com");

            Assert.AreNotEqual(employee.Email, Email);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeAnDepartmentCompareNewWithOld()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            employee.ChangeDepartment(new Department("Expedition", "nothing", true));

            Assert.AreNotEqual(employee.Department.Name, Depart.Name);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeAnBirthdateCompareNewWithOld()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            employee.ChangeBirthDate(new DateTime(1987, 5, 22));

            Assert.AreNotEqual(employee.BirthDate, BirthDate);
            Assert.IsTrue(employee.Valid);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void ChangeActivationEmployee()
        {
            Employee employee = new Employee(FirstName, LastName, Email, Depart, BirthDate, true);
            Assert.IsTrue(employee.Active);

            employee.Deactivate();
            Assert.IsFalse(employee.Active);
        }

    }
}
