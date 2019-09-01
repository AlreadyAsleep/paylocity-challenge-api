using PaylocityCodingChallenge.Business.Interfaces;
using PaylocityCodingChallenge.Data.Interfaces;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDiscountBL _discountBL;

        public EmployeeService( IEmployeeRepository employeeRepository, IDiscountBL discountBL)
        { 
            _employeeRepository = employeeRepository;
            _discountBL = discountBL;
        }

        /// <summary>
        /// Adds an employee to the database
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>An updated employee that has reflects what is in the database</returns>
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _discountBL.ApplyDiscounts(employee);
            return await _employeeRepository.AddEmployeeAsync(employee);
        }
    }
}
