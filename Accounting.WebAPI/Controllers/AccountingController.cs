using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Domain.Business;
using Accounting.Dto.Requests;
using Accounting.Dto.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountingController(IAccountService accountService)
        {
            this.accountService = accountService ?? throw new ArgumentNullException("AccountService is null");
        }

        /// <summary>
        /// Top up your wallet in one of the currencies.
        /// </summary>
        /// <param name="request">Wallet replenishment request</param>
        /// <returns>Wallet replenishment response</returns>
        [HttpPost]
        [Route("AddPayment")]
        public async Task<AddPaymentResponse> AddPaymentAsync([FromBody] AddPaymentRequest request)
        {
            return await accountService.AddPaymentAsync(request);
        }

        /// <summary>
        /// Withdraw money in one of the currencies.
        /// </summary>
        /// <param name="request">Withdrawal request in one of the currencies</param>
        /// <returns>Response to withdrawing money in one of the currencies</returns>
        [HttpPost]
        [Route("WithdrawPayment")]
        public async Task<WithdrawPaymentResponse> WithdrawPaymentAsync([FromBody] WithdrawPaymentRequest request)
        {
            return await accountService.WithdrawPaymentAsync(request);
        }

        /// <summary>
        /// Transfer money from one currency to another.
        /// </summary>
        /// <param name="request">Request for money transfer from one currency to another</param>
        /// <returns>Response to the transfer of money from one currency to another</returns>
        [HttpPost]
        [Route("TransferMoneyBetweenAccount")]
        public async Task<TransferMoneyBetweenAccountResponse> TransferMoneyBetweenAccountAsync([FromBody] TransferMoneyBetweenAccountRequest request)
        {
            return await accountService.TransferMoneyBetweenAccountAsync(request);
        }

        /// <summary>
        /// Get the status of your wallet (the amount of money in each currency).
        /// </summary>
        /// <param name="request">Request for getting the status of your accounts</param>
        /// <returns>Response to getting your account status</returns>
        [HttpGet]
        [Route("AccountState")]
        public async Task<AccountStateResponse> GetAccountStateAsync([FromQuery] AccountStateRequest request)
        {
            return await accountService.AccountStateAsync(request);
        }
    }
}