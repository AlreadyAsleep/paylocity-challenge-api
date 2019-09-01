using PaylocityCodingChallenge.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public sealed class Employee : Person
    {
        public long EmployeeId { get; set; }
        public ICollection<Dependent> Dependents {get; set;}
        public ICollection<EmployeeDiscount> Discounts { get; set; }
        public Employee() => BenefitRate = new BenefitRate { BenefitRateId = (byte)BenefitType.Employee };
    }
}
