using System.Collections.Generic;
using TJ.UserAccount.Integration.Models;
using System.Threading.Tasks;
using Flurl.Http;
using TJ.UserAccount.Integration.Exceptions;
using Flurl.Http.Xml;
namespace TJ.UserAccount.Integration
{
    /// <summary>
    /// Клиетн к обменной бирже
    /// </summary>
    public class ExchangeRateClient
    {
        private readonly string _exchangeRateUrl;

        public ExchangeRateClient(string exchangeRateUrl)
        {
            _exchangeRateUrl=exchangeRateUrl;
        }
        /// <summary>
        /// Курсы валют
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ExchangeRate>> ExchangeRatesAsync()
        {
            var stockExchangeResponse =await _exchangeRateUrl.GetAsync().ReceiveXml<Envelope>()
                ??throw new ExchangeRateException("Не удалось разобрать обменный курс");
            return stockExchangeResponse.Cube.ExchangeRate.ExchangeRates;
        }       
    }
}
