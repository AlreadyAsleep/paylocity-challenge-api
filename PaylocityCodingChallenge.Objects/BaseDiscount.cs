using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Objects
{
    public abstract class BaseDiscount
    {
        public virtual DiscountRate DiscountRate { get; set; }
    }
}
