using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Business.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Adds an employee to the database
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>An updated employee that has reflects what is in the database</returns>
        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
