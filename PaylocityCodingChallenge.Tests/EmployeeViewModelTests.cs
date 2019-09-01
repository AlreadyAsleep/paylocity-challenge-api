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
    public class EmployeeViewModelTests
    {
        [TestMethod]
        public void ConvertFromEmployeeWithNoDiscounts()
        {
            //Arrange
            var employee = new Employee
            {
                FirstName = "Ben",
                LastName = "Heil",
                EmployeeId = 1,
                BenefitRate = new BenefitRate
                {
                    BenefitRateId = (byte)BenefitType.Employee,
                    Rate = 1000.00m
                }
            };

            //Act
            var model = (EmployeeViewModel)employee;

            //Assert
            Assert.IsTrue(model.AnnualCost == 1000.00m);
            Assert.IsTrue(model.Discount == 0);
        }

        [TestMethod]
        public void ConvertFromEmployeeWithADiscount()
        {
            //Arrange
            var employee = new Employee
            {
                FirstName = "Ben",
                LastName = "Heil",
                EmployeeId = 1,
                BenefitRate = new BenefitRate
                {
                    BenefitRateId = (byte)BenefitType.Employee,
                    Rate = 1000.00m
                },
                Discounts = new List<EmployeeDiscount>()
            };
            var employeeDiscount = new EmployeeDiscount
            {
                DiscountRate = new DiscountRate
                {
                    PercentageDeducted = .1m
                }
            };
            employee.Discounts.Add(employeeDiscount);

            //Act
            var model = (EmployeeViewModel)employee;

            //Assert
            Assert.IsTrue(model.AnnualCost == 900.00m);
            Assert.IsTrue(model.Discount == 100.00m);
        }
    }
}
