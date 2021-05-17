using Microsoft.Extensions.DependencyInjection;
using TJ.UserAccount.Services.Abstractions;

namespace TJ.UserAccount.Services
{
    public static class Entry
    {
        /// <summary>
        /// Регистрация сервисов
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAccountServices(this IServiceCollection services)
        {
            return services.AddTransient<IAccountService, AccountService>();
        }
    }
}
