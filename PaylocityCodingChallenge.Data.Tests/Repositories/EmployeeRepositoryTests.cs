using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaylocityCodingChallenge.Data.Repositories;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Tests.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository employeeRepository;

        [TestInitialize]
        public void Initialize()
        {
            employeeRepository = new EmployeeRepository(true);
        }

        [TestCleanup]
        public void Cleanup()
        {
            var context = employeeRepository.GetDbContext();
            context.Employees.RemoveRange(context.Employees);
            context.Dependents.RemoveRange(context.Dependents);
            context.BenefitRates.RemoveRange(context.BenefitRates);
            context.Discounts.RemoveRange(context.Discounts);
            context.SaveChanges();
        }

        [TestMethod]
        public async Task GetEmployeeByIdWithNoEntry()
        {
            //Act
            var employee = await employeeRepository.GetEmployeeByIdAsync(1);

            //Assert
            Assert.IsNull(employee);
        }

        [TestMethod]
        public async Task GetEmployeeByIdWithAnEntry()
        {
            //Arrange
            var context = employeeRepository.GetDbContext();
            var testEmployee = new Employee { EmployeeId = 1, FirstName = "Ben", LastName = "Heil" };
            context.Employees.Add(testEmployee);
            context.SaveChanges();

            //Act
            var employee = await employeeRepository.GetEmployeeByIdAsync(1);

            //Assert
            Assert.AreEqual(employee.FirstName, "Ben");
        }

        [TestMethod]
        public async Task GetEmployeeByIdWithAnEntryAndDependent()
        {
            //Arrange
            var context = employeeRepository.GetDbContext();
            var testDependent = new Dependent { DependentId = 1, EmployeeId = 1, FirstName = "Mike", LastName = "Person" };
            var testEmployee = new Employee { EmployeeId = 1, FirstName = "Ben", LastName = "Heil" };
            testEmployee.Dependents = new List<Dependent>();
            testEmployee.Dependents.Add(testDependent);
            context.Employees.Add(testEmployee);
            context.SaveChanges();

            //Act
            var employee = await employeeRepository.GetEmployeeByIdAsync(1);

            //Assert
            Assert.AreEqual(employee.Dependents.First().DependentId, 1);
        }

        [TestMethod]
        public async Task AddEmployeeWithNoDependents()
        {
            //Arrange
            var testEmployee = new Employee { FirstName = "Ben", LastName = "Heil" };

            //Act
            var employee = await employeeRepository.AddEmployeeAsync(testEmployee);

            //Assert
            Assert.AreNotEqual(employee.EmployeeId, 0);
        }

        [TestMethod]
        public async Task AddEmployeeWithDependent()
        {
            //Arrange
            var testDependent = new Dependent { FirstName = "Mike", LastName = "Person" };
            var testEmployee = new Employee { FirstName = "Ben", LastName = "Heil" };
            testEmployee.Dependents = new List<Dependent>();
            testEmployee.Dependents.Add(testDependent);

            //Act
            var employee = await employeeRepository.AddEmployeeAsync(testEmployee);

            //Assert
            Assert.AreNotEqual(employee.EmployeeId, 0);
            Assert.AreNotEqual(employee.Dependents.First().EmployeeId, 0);
            Assert.AreNotEqual(employee.Dependents.First().DependentId, 0);
        }
    }
}
