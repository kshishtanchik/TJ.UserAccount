using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ.UserAccount.Contracts;
using TJ.UserAccount.Services.Abstractions;

namespace TJ.UserAccount.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        /// <summary>
        /// Пополнить кошелек в одной из валют
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currencyCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost("ReplenishWallet")]
        public ActionResult<List<AccountStatus>> ReplenishWallet([FromBody]Bid bid)
        {
            try
            {
                var status= _accountService.ReplenishWallet(bid);
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Снять деньги
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpPost("WithdrawMoney")]
        public ActionResult<List<AccountStatus>> WithdrawMoney([FromBody]Bid bid)
        {
            try
            {
                var status =_accountService.WithdrawMoney(bid);
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Перевести из одной валюты в другую
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpPost("TransferMoney")]
        public ActionResult<List<AccountStatus>> TransferMoney([FromBody] TransferBid bid)
        {
            try
            {
                var status = _accountService.TransferMoneyAsync(bid);
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Состояние счета пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AccountStatus>> AccountStatus(string userId)
        {
            try
            {
                var status = _accountService.AccountStatus(userId);
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
