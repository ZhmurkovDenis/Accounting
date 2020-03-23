using Accounting.DataAccess.Infrastructure.Abstractions;
using Accounting.Domain.DataAccess;
using Accounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.DataAccess
{
    public class AccountDataAccess : IAccountDataAccess
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountDataAccess(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("IUnitOfWork in AccountDataAccess is null");
        }

        public Task<Account> GetByIdAsync(int id)
        {
            return unitOfWork.Accounts.GetItemAsync(id);
        }

        public Task<IList<Account>> GetAllAsync()
        {
            return unitOfWork.Accounts.GetItemsAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await unitOfWork.Accounts.DeleteAsync(id);
            var res = await unitOfWork.Accounts.SaveAsync();
            return res > 0;
        }

        public async Task<bool> SaveOrUpdateAsync(Account account)
        {
            var accountToUpdate = await GetByIdAsync(account.Id);

            if (accountToUpdate == null)
            {
                await unitOfWork.Accounts.CreateAsync(account);
            }
            else
            {
                await unitOfWork.Accounts.UpdateAsync(account);
            }

            var res = await unitOfWork.Accounts.SaveAsync();
            return res > 0;
        }

        public Task<IList<Account>> GetAllByUserAsync(int userId)
        {
            return unitOfWork.Accounts.GetAllByUserAsync(userId);
        }

        public Task<Account> GetByUserCurrencyAsync(int userId, int currencyId)
        {
            return unitOfWork.Accounts.GetByUserCurrencyAsync(userId, currencyId);
        }
    }
}
