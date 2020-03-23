using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Requests
{
    /// <summary>
    /// Wallet replenishment request.
    /// </summary>
    public class AddPaymentRequest
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
