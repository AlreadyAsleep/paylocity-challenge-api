using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public sealed class DiscountRate
    {
        public int DiscountRateId { get; set; }
        public decimal PercentageDeducted { get; set; }
    }
}
