using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Context.Mappers
{
    public static class EmployeeMapper
    {
        public static void MapEmployees(this ModelBuilder builder)
        {
            builder.Entity<Employee>(employee =>
            {
                employee.ToTable("Employee");
                employee.HasKey(e => e.EmployeeId);
                employee.HasMany(e => e.Dependents)
                .WithOne().HasForeignKey(dependent => dependent.EmployeeId);
                employee.HasOne(e => e.BenefitRate);
                employee.HasMany(e => e.Discounts);
            });
        }
    }
}
