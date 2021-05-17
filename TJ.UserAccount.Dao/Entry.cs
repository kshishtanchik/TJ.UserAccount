using Microsoft.Extensions.DependencyInjection;
using TJ.UserAccount.Dao.Abstractions;
using TJ.UserAccount.Dao.Implementation;

namespace TJ.UserAccount.Dao
{
    public static class Entry
    {
        /// <summary>
        /// Регистрация репозиториев
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepo(this IServiceCollection services)
        {
            return services.AddTransient<IAccountRepo, FakeAccountRepo>();
        }
    }
}
