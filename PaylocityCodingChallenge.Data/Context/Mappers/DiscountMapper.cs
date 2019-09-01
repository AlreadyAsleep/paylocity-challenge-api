using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Context.Mappers
{
    public static class DiscountMapper
    {
        public static void MapDiscounts(this ModelBuilder builder)
        {
            builder.Entity<DiscountRate>(discount =>
            {
                discount.ToTable("DiscountRate");
                discount.HasKey(x => x.DiscountRateId);
            });

            builder.Entity<EmployeeDiscount>(employeeDiscount =>
            {
                employeeDiscount.ToTable("EmployeeDiscountMapping");
                employeeDiscount.HasKey(x => x.EmployeeDiscountMappingId);
                employeeDiscount.HasOne(x => x.DiscountRate);
            });

            builder.Entity<DependentDiscount>(dependentDiscount =>
            {
                dependentDiscount.ToTable("DependentDiscountMapping");  
                dependentDiscount.HasKey(x => x.DependentDiscountMappingId);
                dependentDiscount.HasOne(x => x.DiscountRate);
            });
        }
    }
}
