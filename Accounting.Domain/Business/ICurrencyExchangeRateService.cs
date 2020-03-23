using Accounting.Dto.Requests;
using Accounting.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Business
{
    public interface ICurrencyRateService
    {
        Task<CurrencyRateResponse> GetCurrencyRate(CurrencyRateRequest request);
    }
}
