using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Dto
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
