using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public sealed class EmployeeDiscount : BaseDiscount
    {
        public long EmployeeDiscountMappingId { get; set; }
        public long EmployeeId { get; set; }
    }
}
