using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaylocityCodingChallenge.Models
{
    public sealed class DependentViewModel : PersonViewModel
    {
        public static explicit operator DependentViewModel(Dependent dependent)
        {
            var discount = dependent.BenefitRate.Rate * dependent.Discounts?.Select(x => x.DiscountRate.PercentageDeducted).Sum() ?? 0;
            return new DependentViewModel
            {
                FirstName = dependent.FirstName,
                LastName = dependent.LastName,
                AnnualCost = dependent.BenefitRate.Rate - discount,
                Discount = discount
            };
        }

        public static explicit operator Dependent(DependentViewModel dependent)
        {
            return new Dependent
            {
                FirstName = dependent.FirstName,
                LastName = dependent.LastName
            };
        }
    }
}