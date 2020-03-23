using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Requests
{
    /// <summary>
    /// Withdrawal request in one of the currencies.
    /// </summary>
    public class WithdrawPaymentRequest
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
