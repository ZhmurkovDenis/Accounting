using Accounting.Dto.Requests;
using Accounting.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Business
{
    public interface IAccountService
    {
        /// <summary>
        /// Top up your wallet in one of the currencies.
        /// </summary>
        /// <param name="request">Wallet replenishment request</param>
        /// <returns>Wallet replenishment response</returns>
        Task<AddPaymentResponse> AddPaymentAsync(AddPaymentRequest request);
        /// <summary>
        /// Withdraw money in one of the currencies.
        /// </summary>
        /// <param name="request">Withdrawal request in one of the currencies</param>
        /// <returns>Response to withdrawing money in one of the currencies</returns>
        Task<WithdrawPaymentResponse> WithdrawPaymentAsync(WithdrawPaymentRequest request);
        /// <summary>
        /// Transfer money from one currency to another.
        /// </summary>
        /// <param name="request">Request for money transfer from one currency to another</param>
        /// <returns>Response to the transfer of money from one currency to another</returns>
        Task<TransferMoneyBetweenAccountResponse> TransferMoneyBetweenAccountAsync(TransferMoneyBetweenAccountRequest request);
        /// <summary>
        /// Get the status of your wallet (the amount of money in each currency).
        /// </summary>
        /// <param name="request">Request for getting the status of your accounts</param>
        /// <returns>Response to getting your account status</returns>
        Task<AccountStateResponse> AccountStateAsync(AccountStateRequest request);
    }
}
