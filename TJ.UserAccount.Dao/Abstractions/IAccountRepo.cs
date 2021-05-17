using System.Collections.Generic;
using TJ.UserAccount.Dao.Models;

namespace TJ.UserAccount.Dao.Abstractions
{
    /// <summary>
    /// Репозиторий для доступа к данным пользователя
    /// </summary>
    public interface IAccountRepo
    {
        /// <summary>
        /// Добавить денег
        /// </summary>
        /// <param name="bid">Заявка</param>
        /// <returns>Состояние счетов пользователя</returns>
        IEnumerable<AccountStatus> AddMoney(Bid bid);

        /// <summary>
        /// Счета пользователя
        /// </summary>
        /// <param name="userId">Заявка</param>
        /// <returns>Состояние счетов пользователя</returns>
        IEnumerable<AccountStatus> GetAccountStatuses(string userId);

        /// <summary>
        /// Снять деньги
        /// </summary>
        /// <param name="bid">Заявка</param>
        /// <returns>Состояние счетов пользователя</returns>
        IEnumerable<AccountStatus> WithdrawMoney(Bid bid);
    }
}