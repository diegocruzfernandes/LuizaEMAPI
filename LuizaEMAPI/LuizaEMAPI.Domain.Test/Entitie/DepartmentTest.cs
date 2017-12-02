using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizaEMAPI.Domain.Entities;

namespace LuizaEMAPI.Domain.Test.Entitie
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
            Department depart = new Department(Name, Description, true);
            Assert.IsTrue(depart.Valid);
        }

        [TestMethod]
        [TestCategory("Department")]
        public void GivenAnInvalidNameShouldReturnNotification()
        {
            //Don't empty
            Department depart = new Department("", Description, true);
            Assert.IsFalse(depart.Valid);

            //length > 3
            Department depart2 = new Department("ad", Description, true);
            Assert.IsFalse(depart2.Valid);

            //length < 60
            Department depart3 = new Department("1234567890123456789012345678901234567890123456789012345678901", Description, true);
            Assert.IsFalse(depart.Valid);
        }

        [TestMethod]
        [TestCategory("Department")]
        public void GivenAnInvalidDescriptionShouldReturnNotification()
        {
            //length < 200
            Department depart = new Department(Name, "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901", true);
            Assert.IsFalse(depart.Valid);
        }

        [TestMethod]
        [TestCategory("Department")]
        public void ChangeActivationDepartment()
        {
            Department depart = new Department(Name, Description, true);

            depart.Activate();
            Assert.IsTrue(depart.Active);

            depart.Deactivate();
            Assert.IsFalse(depart.Active);

        }

        [TestMethod]
        [TestCategory("Department")]
        public void ChangeNameDepartmentCompareNewWithOld()
        {
            Department depart = new Department(Name, Description, true);

            Assert.AreEqual(depart.Name, Name);

            depart.ChangeName("Expedition");
            Assert.AreNotEqual(depart.Name, Name);
        }

        [TestMethod]
        [TestCategory("Department")]
        public void ChangeDescriptionDepartmentCompareNewWithOld()
        {
            Department depart = new Department(Name, Description, true);

            Assert.AreEqual(depart.Description, Description);

            depart.ChangeDescription("Where orders are despatched");
            Assert.AreNotEqual(depart.Description, Description);
        }


    }
}
