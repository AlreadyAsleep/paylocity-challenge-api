using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaylocityCodingChallenge.Business.Interfaces;
using PaylocityCodingChallenge.Objects;
using PaylocityCodingChallenge.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Business.Tests
{
    [TestClass]
    public class DiscountBLTests
    {
        private DiscountBL _discountBL;

        [TestInitialize]
        public void Initialize()
        {
            _discountBL = new DiscountBL();
        }

        [TestMethod]
        public void TestApplyDiscountsWithNoEligibleDiscounts()
        {
            //Arrange
            var testEmployee = new Employee
            {
                FirstName = "Ben",
                LastName = "Heil",
                Dependents = new List<Dependent>()
            };
            var testDependent = new Dependent
            {
                FirstName = "Mike",
                LastName = "Dude",
            };
            testEmployee.Dependents.Add(testDependent);

            //Act
            var employee = _discountBL.ApplyDiscounts(testEmployee);

            //Assert
            Assert.IsNull(employee.Discounts);
        }

        [TestMethod]
        public void TestApplyDiscountsWithEmployeeEligibleForDiscounts()
        {
            //Arrange
            var testEmployee = new Employee
            {
                FirstName = "Adam",
                LastName = "Heil",
                Dependents = new List<Dependent>()
            };
            var testDependent = new Dependent
            {
                FirstName = "Mike",
                LastName = "Dude",
            };
            testEmployee.Dependents.Add(testDependent);

            //Act
            var employee = _discountBL.ApplyDiscounts(testEmployee);

            //Assert
            Assert.IsTrue(employee.Discounts.First().DiscountRate.DiscountRateId == (int)DiscountType.NameBeginsWithA);
            Assert.IsNull(employee.Dependents.First().Discounts);
        }

        [TestMethod]
        public void TestApplyDiscountsWithEmployeeAndDependentEligibleForDiscounts()
        {
            //Arrange
            var testEmployee = new Employee
            {
                FirstName = "Adam",
                LastName = "Heil",
                Dependents = new List<Dependent>()
            };
            var testDependent = new Dependent
            {
                FirstName = "Alex",
                LastName = "Dude",
            };
            testEmployee.Dependents.Add(testDependent);

            //Act
            var employee = _discountBL.ApplyDiscounts(testEmployee);

            //Assert
            Assert.IsTrue(employee.Discounts.First().DiscountRate.DiscountRateId == (int)DiscountType.NameBeginsWithA);
            Assert.IsTrue(employee.Dependents.First().Discounts.First().DiscountRate.DiscountRateId == (int)DiscountType.NameBeginsWithA);
        }
    }
}
