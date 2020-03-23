using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Responses
{
    public class CurrencyRateResponse : BaseResponse
    {
        public decimal CurrencyRate { get; set; }
    }
}
