using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Requests
{
    public class CurrencyRateRequest
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
    }
}
