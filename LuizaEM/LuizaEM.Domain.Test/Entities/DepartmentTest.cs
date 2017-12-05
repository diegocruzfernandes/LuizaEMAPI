using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEM.Domain.Entities;

namespace LuizaEM.Domain.Tests.Entities
{
    [TestClass]
    public class DepartmentTest
    {

        private string Name = "Administration";
        private string Description = "Manages all sectors of the company";

        [TestMethod]
        [TestCategory("Department")]
        public void CreateNewInstanceDepartment()
        {
            Department depart = new Department(0, Name, Description, true);
            Assert.IsTrue(depart.IsValid());
        }

        [TestMethod]
        [TestCategory("Department")]
        public void GivenAnInvalidNameShouldReturnNotification()
        {
            //Don't empty
            Department depart = new Department(0, "", Description, true);
            Assert.IsFalse(depart.IsValid());

            //length > 3
            Department depart2 = new Department(0,"ad", Description, true);
            Assert.IsFalse(depart2.IsValid());

            //length < 60
            Department depart3 = new Department(0,"1234567890123456789012345678901234567890123456789012345678901", Description, true);
            Assert.IsFalse(depart.IsValid());
        }

        [TestMethod]
        [TestCategory("Department")]
        public void GivenAnInvalidDescriptionShouldReturnNotification()
        {
            //length < 200
            Department depart = new Department(0,Name, "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901", true);
            Assert.IsFalse(depart.IsValid());
        }

        [TestMethod]
        [TestCategory("Department")]
        public void ChangeActivationDepartment()
        {
            Department depart = new Department(0,Name, Description, true);

            depart.Activate();
            Assert.IsTrue(depart.Active);

            depart.Deactivate();
            Assert.IsFalse(depart.Active);

        }

        [TestMethod]
        [TestCategory("Department")]
        public void UpdateDataDepartmentCompareNewWithOld()
        {
            Department depart = new Department(0,Name, Description, true);

            Assert.AreEqual(depart.Name, Name);
            Assert.AreEqual(depart.Description, Description);

            depart.UpdateData("Expedition", "Where orders are despatched", false);
            Assert.AreNotEqual(depart.Name, Name);
            Assert.AreNotEqual(depart.Description, Description);
            Assert.IsFalse (depart.Active);

        }

      


    }
}
