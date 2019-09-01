using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaylocityCodingChallenge.Models
{
    public sealed class EmployeeViewModel : PersonViewModel
    {
        public long EmployeeId { get; set; }
        public IEnumerable<DependentViewModel> Dependents { get; set; }

        public static explicit operator EmployeeViewModel(Employee employee)
        {
            var discount = employee.BenefitRate.Rate * employee.Discounts?.Select(x => x.DiscountRate.PercentageDeducted).Sum() ?? 0;
            return new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Dependents = employee.Dependents?.Select(x => (DependentViewModel)x),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                AnnualCost = employee.BenefitRate.Rate - discount,
                Discount = discount
            };
        }

        public static explicit operator Employee(EmployeeViewModel employee)
        {
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                Dependents = employee.Dependents?.Select(x => (Dependent)x).ToList(),
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }
    }
}