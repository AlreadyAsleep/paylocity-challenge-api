using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Context.Mappers
{
    public static class DependentMapper
    {
        public static void MapDependents(this ModelBuilder builder)
        {
            builder.Entity<Dependent>(dependent =>
            {
                dependent.ToTable("Dependent");
                dependent.HasKey(x => x.DependentId);
                dependent.HasOne(x => x.BenefitRate);
                dependent.HasMany(x => x.Discounts);
            });
        }
    }
}
