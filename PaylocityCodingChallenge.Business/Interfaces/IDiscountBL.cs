using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Business.Interfaces
{
    public interface IDiscountBL
    {
        /// <summary>
        /// Adds discount objects to an employee based off of business criteria
        /// </summary>
        /// <param name="employee">The employee affected</param>
        /// <returns>An employee object with the discounts added</returns>
        Employee ApplyDiscounts(Employee employee);
    }
}
