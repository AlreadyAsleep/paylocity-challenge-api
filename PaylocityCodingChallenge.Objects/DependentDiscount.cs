 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public sealed class DependentDiscount : BaseDiscount
    {
        public long DependentDiscountMappingId { get; set; }
        public long DependentId { get; set; }
    }
}
