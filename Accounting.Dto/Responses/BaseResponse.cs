using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Dto.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
    }
}
