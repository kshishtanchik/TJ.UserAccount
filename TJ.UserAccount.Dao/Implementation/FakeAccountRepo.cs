using System.Collections.Generic;
using System.Linq;
using TJ.UserAccount.Dao.Abstractions;
using TJ.UserAccount.Dao.Exceptions;
using TJ.UserAccount.Dao.Models;

namespace TJ.UserAccount.Dao.Implementation
{
    /// <summary>
    /// Фейковый репозиторий. Заменить на нормальный работающий с базой
    /// </summary>
    public class FakeAccountRepo : IAccountRepo
    {
        private readonly List<AccountStatus> _context;
        private readonly Dictionary<string, Dictionary<string, decimal>> _normContext;

        public FakeAccountRepo()
        {
            _context = new List<AccountStatus>();

            _normContext =new Dictionary<string, Dictionary<string, decimal>>();
        }

        /// <summary>
        /// Счета пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<AccountStatus> GetAccountStatuses(string userId)
        {
            if (_normContext.TryGetValue(userId, out var account))
                return account.Select(v => new AccountStatus { UserId = userId, CurrencyCode = v.Key, Amount = v.Value });
            throw new AccountRepoException($"Пользователь с идентификатором {userId} не существет");
        }

        /// <summary>
        /// Добавить денег
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public IEnumerable<AccountStatus> AddMoney(Bid bid)
        {
            if (!_normContext.TryGetValue(bid.UserId, out var account))
                throw new AccountRepoException($"Пользователь с идентификатором {bid.UserId} не существет");
            if (!account.TryGetValue(bid.CurrencyCode, out var curamount))
                throw new AccountRepoException($"У пользователя с идентификатором {bid.UserId} нет счета в валюте {bid.CurrencyCode}");
            curamount += bid.Amount;
            return account.Select(v => new AccountStatus { UserId = bid.UserId, CurrencyCode = v.Key, Amount = v.Value });
        }

        //todo:добавление пользователю валюты

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<AccountStatus> AddUser(string userId)
        {
            _context.Add(new AccountStatus { UserId = userId });
            return GetAccountStatuses(userId);
        }

        /// <summary>
        /// Снять деньги
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public IEnumerable<AccountStatus> WithdrawMoney(Bid bid)
        {
            var userAccounts = _context.Where(x => x.UserId.Equals(bid.UserId))
                ?? throw new AccountRepoException($"Пользователь с идентификатором {bid.UserId} не существет");
            var moneyAcount = userAccounts.FirstOrDefault(x => x.CurrencyCode.Equals(bid.CurrencyCode))
                ?? throw new AccountRepoException($"У пользователя с идентификатором {bid.UserId} нет счета в валюте {bid.CurrencyCode}");
            moneyAcount.Amount -= bid.Amount;
            return userAccounts;
        }
    }
}
