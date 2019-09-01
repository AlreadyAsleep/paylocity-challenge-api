using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Data.Context;
using PaylocityCodingChallenge.Data.Interfaces;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(bool inMemory = false) : base(inMemory)
        {
        }

        /// <summary>
        /// Add an employee to the database
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>The employee from the database</returns>
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            using(var context = GetDbContext())
            {
                context.Employees.Attach(employee);
                await context.SaveChangesAsync();
                return await GetEmployeeByIdAsync(employee.EmployeeId);
            }
        }

        /// <summary>
        /// Get every employee in the database including dependents
        /// </summary>
        /// <returns>A collection of employees</returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using(var context = GetDbContext())
            {
                return await context.Employees
                    .Include(employee => employee.Dependents)
                        .ThenInclude(dependent => dependent.BenefitRate)
                    .Include(employee => employee.Dependents)
                        .ThenInclude(dependent => dependent.Discounts)
                            .ThenInclude(depDiscount => depDiscount.DiscountRate)
                    .Include(employee => employee.BenefitRate)
                    .Include(employee => employee.Discounts)
                        .ThenInclude(empDiscount => empDiscount.DiscountRate)
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Get one employee from the database by employee id
        /// </summary>
        /// <param name="employeeId">The id of the employee to get</param>
        /// <returns>An employee object</returns>
        public async Task<Employee> GetEmployeeByIdAsync(long employeeId)
        {
            using(var context = GetDbContext())
            {
                return await context.Employees
                    .Where(employee => employee.EmployeeId == employeeId)
                    .Include(employee => employee.Dependents)
                        .ThenInclude(dependent => dependent.BenefitRate)
                    .Include(employee => employee.Dependents)
                        .ThenInclude(dependent => dependent.Discounts)
                            .ThenInclude(depDiscount => depDiscount.DiscountRate)
                    .Include(employee => employee.BenefitRate)
                    .Include(employee => employee.Discounts)
                        .ThenInclude(empDiscount => empDiscount.DiscountRate)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
