using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TJ.UserAccount.Contracts;
using TJ.UserAccount.Dao.Abstractions;
using TJ.UserAccount.Integration;
using TJ.UserAccount.Services.Abstractions;
using dto = TJ.UserAccount.Services.Dto;
using dao = TJ.UserAccount.Dao.Models;
using System.Threading.Tasks;

namespace TJ.UserAccount.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IMapper _mapper;
        private readonly ExchangeRateClient _client;

        public AccountService(IAccountRepo accountRepo, ExchangeRateClient rateClient, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
            _client = rateClient;
        }

        public IEnumerable<AccountStatus> AccountStatus(string userId)
        {
            var repoStatuses=_accountRepo.GetAccountStatuses(userId);
            return repoStatuses.Select(_mapper.Map<AccountStatus>);
        }

        public IEnumerable<AccountStatus> ReplenishWallet(Bid bid)
        {
            var daoDto = _mapper.Map<dao.Bid>(bid);
            var statuses = _accountRepo.AddMoney(daoDto);
            return statuses.Select(_mapper.Map<AccountStatus>);
        }

        public async Task<IEnumerable<AccountStatus>> TransferMoneyAsync(TransferBid bid)
        {
            var bidDto = _mapper.Map<dto.TransferBid>(bid);
            var rates =await _client.ExchangeRatesAsync();
            var currentRate = rates.FirstOrDefault(x => x.currency.ToLower() == bidDto.CurrencyCode.ToLower());
            var targetRate=  rates.FirstOrDefault(x=>x.currency.ToLower() == bidDto.TargetCurrencyCode.ToLower());
            var creditAmount = bidDto.Amount / currentRate.rate * targetRate.rate;
            var daoDto = _mapper.Map<dao. TransferBid>(bid);
            _accountRepo.WithdrawMoney(daoDto);
            var actualStatus = _accountRepo.AddMoney(new dao.Bid
            {
                Amount = creditAmount,
                CurrencyCode = targetRate.currency,
                UserId = daoDto.UserId
            });
            return actualStatus.Select(_mapper.Map<AccountStatus>);
        }

        public IEnumerable<AccountStatus> WithdrawMoney(Bid bid)
        {
             var bidDto = _mapper.Map<dao.Bid>(bid);
            var statuses = _accountRepo.WithdrawMoney(bidDto);
            return statuses.Select(_mapper.Map<AccountStatus>);            
        }
    }
}
