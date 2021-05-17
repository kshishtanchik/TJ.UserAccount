using Microsoft.Extensions.DependencyInjection;

namespace TJ.UserAccount.Integration
{
    public static class Entry
    {
        /// <summary>
        /// Регистрация клиента обменника
        /// </summary>
        /// <param name="services"></param>
        /// <param name="exchangeRateUrl"></param>
        /// <returns></returns>
        public static IServiceCollection AddExchangeRateClient(this IServiceCollection services,
            string exchangeRateUrl)
        {
            return services.AddTransient<ExchangeRateClient>(x=>new ExchangeRateClient(exchangeRateUrl));
        }
    }
}