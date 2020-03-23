using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Dto
{
    /// <summary>
    /// User account. 
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
