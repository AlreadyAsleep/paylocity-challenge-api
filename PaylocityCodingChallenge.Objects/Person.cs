using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BenefitRate BenefitRate { get; set; }
    }
}
