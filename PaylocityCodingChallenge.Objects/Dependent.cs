using PaylocityCodingChallenge.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public sealed class Dependent : Person
    {
        public long DependentId { get; set; }
        public long EmployeeId { get; set; }
        public ICollection<DependentDiscount> Discounts {get; set;}
        public Dependent() => BenefitRate = new BenefitRate { BenefitRateId = (byte)BenefitType.Dependent };
    }
}
