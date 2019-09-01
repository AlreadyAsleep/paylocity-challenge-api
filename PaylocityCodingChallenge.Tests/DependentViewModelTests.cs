using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaylocityCodingChallenge.Models;
using PaylocityCodingChallenge.Objects;
using PaylocityCodingChallenge.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Tests
{
    [TestClass]
    public class DependentViewModelTests
    {
        [TestMethod]
        public void ConvertFromDependentWithNoDiscounts()
        {
            //Arrange
            var dependent = new Dependent
            {
                FirstName = "Ben",
                LastName = "Heil",
                BenefitRate = new BenefitRate
                {
                    BenefitRateId = (byte)BenefitType.Employee,
                    Rate = 1000.00m
                }
            };

            //Act
            var model = (DependentViewModel)dependent;

            //Assert
            Assert.IsTrue(model.AnnualCost == 1000.00m);
            Assert.IsTrue(model.Discount == 0);
        }

        [TestMethod]
        public void ConvertFromDependentWithADiscount()
        {
            //Arrange
            var dependent = new Dependent
            {
                FirstName = "Ben",
                LastName = "Heil",
                BenefitRate = new BenefitRate
                {
                    BenefitRateId = (byte)BenefitType.Employee,
                    Rate = 1000.00m
                },
                Discounts = new List<DependentDiscount>()
            };
            var employeeDiscount = new DependentDiscount
            {
                DiscountRate = new DiscountRate
                {
                    PercentageDeducted = .1m
                }
            };
            dependent.Discounts.Add(employeeDiscount);

            //Act
            var model = (DependentViewModel)dependent;

            //Assert
            Assert.IsTrue(model.AnnualCost == 900.00m);
            Assert.IsTrue(model.Discount == 100.00m);
        }
    }
}
