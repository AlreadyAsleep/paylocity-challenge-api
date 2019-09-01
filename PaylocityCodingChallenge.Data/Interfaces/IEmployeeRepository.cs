using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Add an employee to the database
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>The employee from the database</returns>
        Task<Employee> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Get every employee in the database including dependents
        /// </summary>
        /// <returns>A collection of employees</returns>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        /// <summary>
        /// Get one employee from the database by employee id
        /// </summary>
        /// <param name="employeeId">The id of the employee to get</param>
        /// <returns>An employee object</returns>
        Task<Employee> GetEmployeeByIdAsync(long employeeId);
    }
}
