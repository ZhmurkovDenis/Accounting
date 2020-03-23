using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Accounting.Domain.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
