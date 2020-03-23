using Accounting.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infastructure.Absractions
{
    public interface ICurrencyRateClient
    {
        Task<IList<CurrencyRate>> GetCurrencyRates();
    }
}
