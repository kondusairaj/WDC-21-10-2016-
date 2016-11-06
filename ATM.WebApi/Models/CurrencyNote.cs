using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class CurrencyNote
    {
        public int Value { get; set; }
        public int Count { get; set; }
    }

    public class CurrencyDenomination
    {
        public int Value { get; set; }
        public CurrencyDenomination NextDenomination { get; set; }
    }
}
