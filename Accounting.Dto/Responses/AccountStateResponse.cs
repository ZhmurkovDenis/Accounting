using Accounting.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Responses
{
    /// <summary>
    /// Response to getting your account status.
    /// </summary>
    public class AccountStateResponse : BaseResponse
    {
        public IList<Account> Accounts { get; set; }
    }
}
