using Accounting.Dto.Dto;
using Accounting.Infastructure.Absractions;
using Accounting.Infastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Accounting.Infastructure
{
    public class CurrencyRateClient : ICurrencyRateClient
    {
        public async Task<IList<CurrencyRate>> GetCurrencyRates()
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var get = await http.GetAsync(new Uri("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"));
                    var res = await get.Content.ReadAsStringAsync();

                    StringReader stringReader = new StringReader(res);

                    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

                    Envelope envelope = (Envelope)serializer.Deserialize(stringReader);
                    return envelope.Cube.Cube1.Cube.Select(x => new CurrencyRate
                    {
                        CurrencyFrom = new Currency
                        {
                            Code = "EUR",
                        },
                       CurrencyTo = new Currency
                       {
                           Code = x.currency,
                       },
                       Rate = x.rate
                    }).ToList();
                }
            }
            catch(Exception ex)
            {
                // TODO : AddToLog
            }

            return new List<CurrencyRate>();
        }
    }
}
