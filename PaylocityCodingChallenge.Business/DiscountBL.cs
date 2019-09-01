using PaylocityCodingChallenge.Business.Interfaces;
using PaylocityCodingChallenge.Objects;
using PaylocityCodingChallenge.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Business
{
    public class DiscountBL : IDiscountBL
    {
        /// <summary>
        /// Adds discount objects to an employee based off of business criteria
        /// </summary>
        /// <param name="employee">The employee affected</param>
        /// <returns>An employee object with the discounts added</returns>
        public Employee ApplyDiscounts(Employee employee)
        {
            if (employee.FirstName.ToLower().StartsWith("a"))
            {
                employee.Discounts = employee.Discounts ?? new List<EmployeeDiscount>();
                employee.Discounts.Add(new EmployeeDiscount
                {
                    EmployeeId = employee.EmployeeId,
                    DiscountRate = new DiscountRate { DiscountRateId = (int)DiscountType.NameBeginsWithA }
                });
            }
            foreach (var dependent in employee.Dependents)
            {
                if (dependent.FirstName.ToLower().StartsWith("a"))
                {
                    dependent.Discounts = dependent.Discounts ?? new List<DependentDiscount>();
                    dependent.Discounts.Add(new DependentDiscount
                    {
                        DependentId = dependent.DependentId,
                        DiscountRate = new DiscountRate { DiscountRateId = (int)DiscountType.NameBeginsWithA }
                    });
                }
            }
            return employee;
        }
    }

    
}
