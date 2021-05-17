using System;
using TJ.UserAccount.Contracts;
using TJ.UserAccount.Dao.Implementation;
using TJ.UserAccount.Integration;
using TJ.UserAccount.Services;
using TJ.UserAccount.Services.MappingProfiles;
using TJ.UserAccount.Web.Controllers;
using Xunit;

namespace TJ.UserAccount.Tests
{
    public class AccountControllerTest
    {
        private AccountController _controller;

        public AccountControllerTest()
        {
            var mapper = new AutoMapper.MapperConfiguration(x =>
            {
                x.AddProfile<DtoMappingProfile>();
                x.AddProfile<DaoMappingProfile>();
            }).CreateMapper();

            var rateClient = new ExchangeRateClient("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            var accountService = new AccountService(new FakeAccountRepo(), rateClient, mapper);
            _controller = new AccountController(accountService);
        }

        [Theory(DisplayName = "a. Пополнить кошелек в одной из валют")]
        [InlineData("Хомячок","USD","1.23")]
        [InlineData("Рыбка","BGN","1")]
        [InlineData("Винни-пух","USD","3")]
        [InlineData("Телепузик","USD","44,")]
        public void Top_up_your_wallet_in_one_of_the_currencies(string userId,string currencyCode, string amount)
        {
            var bid = new Bid
            {
                UserId = userId,
                CurrencyCode = currencyCode,
                Amount = decimal.Parse(amount)
            };

            var accountStatus = _controller.ReplenishWallet(bid);


        }

        [Fact(DisplayName = "b. Снять деньги в одной из валют")]
        public void Withdraw_money_in_one_of_the_currencies()
        {
            var bid = new Bid
            {
                UserId = "хомячок",
                CurrencyCode = "USD",
                Amount = 1
            };

            var accountStatus = _controller.WithdrawMoney(bid);

        }

        [Fact(DisplayName = "c. Перевести деньги из одной валюты в другую")]
        public void Transfer_money_from_one_currency_to_another()
        {
            var bid = new TransferBid
            {
                UserId = "хомячок",
                CurrencyCode = "USD",
                Amount = 2,
                TargetCurrencyCode="CHF"
            };

            var accountStatus = _controller.TransferMoney(bid);
        }

        [Fact(DisplayName = "d. Получить состояние своего кошелька(сумму денег в каждой из валют)")]
        public void Get_the_state_of_your_wallet()
        {
            var userId = "хомячок";
            var accountStatus = _controller.AccountStatus(userId);
        }

    }
}
