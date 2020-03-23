using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Requests
{
    /// <summary>
    /// Request for getting the status of your accounts.
    /// </summary>
    public class AccountStateRequest
    {
        public int UserId { get; set; }
    }
}
