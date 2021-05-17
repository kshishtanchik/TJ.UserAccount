using System.Collections.Generic;
using System.Threading.Tasks;
using TJ.UserAccount.Contracts;

namespace TJ.UserAccount.Services.Abstractions
{
    public interface IAccountService
    {
        IEnumerable<AccountStatus> ReplenishWallet(Bid bid);
        IEnumerable<AccountStatus> WithdrawMoney(Bid bid);
        IEnumerable<AccountStatus> AccountStatus(string userId);
        Task<IEnumerable<AccountStatus>> TransferMoneyAsync(TransferBid bid);
    }
}