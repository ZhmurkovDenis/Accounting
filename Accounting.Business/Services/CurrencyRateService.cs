using Accounting.Domain.Business;
using Accounting.Domain.DataAccess;
using Accounting.Dto.Requests;
using Accounting.Dto.Responses;
using Accounting.Infastructure.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Business.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRateClient currencyRateClient;
        private ICurrencyDataAccess currencyDataAccess;

        public CurrencyRateService(ICurrencyRateClient currencyRateClient, ICurrencyDataAccess currencyDataAccess)
        {
            this.currencyRateClient = currencyRateClient ?? throw new ArgumentNullException("currencyRateClient is null");
            this.currencyDataAccess = currencyDataAccess ?? throw new ArgumentNullException("currencyDataAccess is null");

        }

        public async Task<CurrencyRateResponse> GetCurrencyRate(CurrencyRateRequest request)
        {
            var currencyFrom = await currencyDataAccess.GetByIdAsync(request.FromCurrencyId);
            var currenctoTo = await currencyDataAccess.GetByIdAsync(request.ToCurrencyId);

            var rates = await currencyRateClient.GetCurrencyRates();

            var rateFrom = rates.FirstOrDefault(x => x.CurrencyTo.Code == currencyFrom.Code);
            if (rateFrom == null)
            {
                return new CurrencyRateResponse
                {
                    Error = $"{currencyFrom.Code} rate not found",
                    IsSuccess = false
                };
            }

            var rateTo = rates.FirstOrDefault(x => x.CurrencyTo.Code == currenctoTo.Code);
            if (rateFrom == null)
            {
                return new CurrencyRateResponse
                {
                    Error = $"{currenctoTo.Code} rate not found",
                    IsSuccess = false
                };
            }

            return new CurrencyRateResponse
            {
                CurrencyRate = rateFrom.Rate / rateTo.Rate,
                IsSuccess = true
            };
        }
    }
}
