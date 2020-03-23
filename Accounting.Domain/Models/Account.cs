using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Accounting.Domain.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public virtual User User { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
