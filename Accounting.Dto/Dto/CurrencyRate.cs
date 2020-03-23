using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Dto
{
    public class CurrencyRate
    {
        public Currency CurrencyFrom { get; set; }
        public Currency CurrencyTo { get; set; }
        public decimal Rate { get; set; }
    }
}
