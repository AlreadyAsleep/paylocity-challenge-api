using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Context.Mappers
{
    public static class BenefitRateMapper
    {
        public static void MapBenefitRates(this ModelBuilder builder)
        {
            builder.Entity<BenefitRate>(benefitRate =>
            {
                benefitRate.ToTable("BenefitRate");
                benefitRate.HasKey(x => x.BenefitRateId);
            });
        }
    }
}
