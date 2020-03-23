using Accounting.Domain.Business;
using Accounting.Domain.DataAccess;
using Accounting.Domain.Mappers;
using Accounting.Dto.Requests;
using Accounting.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataAccess accountDataAccess;
        private readonly ICurrencyRateService currencyRateService;
        private readonly IAccountMapper accountMapper;

        private const string NoAccountFound = "Счёт не найден";
        private const string NoCurrencyRateFound = "Не удалось получить курс валюты";
        private const string FailedToRaiseMoney = "Не удалось перевести деньги с одного счета на другой";


        public AccountService(IAccountDataAccess accountDataAccess, 
                              ICurrencyRateService currencyRateService,
                              IAccountMapper accountMapper)
        {
            this.accountDataAccess = accountDataAccess ?? throw new ArgumentNullException("accountDataAccess is null");
            this.currencyRateService = currencyRateService ?? throw new ArgumentNullException("currencyRateService is null");
            this.accountMapper = accountMapper ?? throw new ArgumentNullException("accountMapper is null");
        }

        public async Task<AddPaymentResponse> AddPaymentAsync(AddPaymentRequest request)
        {
            var result = false;
            
            try
            {
                var account = await accountDataAccess.GetByUserCurrencyAsync(request.UserId, request.CurrencyId);

                if (account == null)
                {
                    result = await accountDataAccess.SaveOrUpdateAsync(new Domain.Models.Account
                    {
                        UserId = request.UserId,
                        CurrencyId = request.CurrencyId,
                        Balance = request.Amount
                    });
                }
                else
                {
                    account.Balance += request.Amount;
                    result = await accountDataAccess.SaveOrUpdateAsync(account);
                }
            }
            catch(Exception ex)
            {
                //TODO: AddToLog
            }

            return new AddPaymentResponse
            {
                IsSuccess = result
            };
        }

        public async Task<WithdrawPaymentResponse> WithdrawPaymentAsync(WithdrawPaymentRequest request)
        {
            var result = false;

            try
            {
                var account = await accountDataAccess.GetByUserCurrencyAsync(request.UserId, request.CurrencyId);

                if (account == null)
                {
                    return new WithdrawPaymentResponse
                    {
                        Error = NoAccountFound,
                        IsSuccess = false
                    };
                }

                account.Balance -= request.Amount;
                result = await accountDataAccess.SaveOrUpdateAsync(account);
            }
            catch (Exception ex)
            {
                //TODO: AddToLog
            }

            return new WithdrawPaymentResponse
            {
                IsSuccess = result
            };
        }

        public async Task<TransferMoneyBetweenAccountResponse> TransferMoneyBetweenAccountAsync(TransferMoneyBetweenAccountRequest request)
        {
            var currencyRate = await currencyRateService.GetCurrencyRate(new CurrencyRateRequest
            {
                FromCurrencyId = request.FromCurrencyId,
                ToCurrencyId  = request.ToCurrencyId
            });

            if (!currencyRate.IsSuccess)
            {
                return new TransferMoneyBetweenAccountResponse
                {
                    Error = NoCurrencyRateFound,
                    IsSuccess = false
                };
            }

            var withdrawPayment = await WithdrawPaymentAsync(new WithdrawPaymentRequest
            {
                CurrencyId = request.FromCurrencyId,
                UserId = request.UserId,
                Amount = request.Amount
            });


            if (!withdrawPayment.IsSuccess)
            {
                return new TransferMoneyBetweenAccountResponse
                {
                    Error = FailedToRaiseMoney,
                    IsSuccess = false
                };
            }

            var addPayment = await AddPaymentAsync(new AddPaymentRequest
            {
                UserId = request.UserId,
                CurrencyId = request.ToCurrencyId,
                Amount = request.Amount * currencyRate.CurrencyRate
            });

            if (!addPayment.IsSuccess)
            {
                await AddPaymentAsync(new AddPaymentRequest
                {
                    Amount = request.Amount,
                    CurrencyId = request.FromCurrencyId,
                    UserId = request.UserId
                });

                return new TransferMoneyBetweenAccountResponse
                {
                    Error = FailedToRaiseMoney,
                    IsSuccess = false
                };
            }

            return new TransferMoneyBetweenAccountResponse
            {
                IsSuccess = true
            };

        }

        public async Task<AccountStateResponse> AccountStateAsync(AccountStateRequest request)
        {
            try
            {
                var accounts = await accountDataAccess.GetAllByUserAsync(request.UserId);
                var dtoAccounts = accountMapper.ToDto(new ReadOnlyCollection<Domain.Models.Account>(accounts));

                return new AccountStateResponse
                {
                    IsSuccess = true,
                    Accounts = dtoAccounts
                };
            }
            catch(Exception ex)
            {
                //TODO: AddToLog
            }

            return new AccountStateResponse
            {
                IsSuccess = false,
                Accounts = new List<Dto.Dto.Account>()
            };
        }
    }
}
