using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Requests
{
    /// <summary>
    /// Request for money transfer from one currency to another.
    /// </summary>
    public class TransferMoneyBetweenAccountRequest
    {
        public int UserId { get; set; }
        public int FromCurrencyId { get; set; }

        public int ToCurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
