using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using Accounting.DataAccess.Infrastructure.Contexts;
using Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure.Repositories
{
    public class AccountRepository : Disposable, IAccountRepository
    {
        private readonly AccountingContext accountingContext;

        public AccountRepository(AccountingContext accountingContext)
        {
            this.accountingContext = accountingContext ?? throw new ArgumentNullException("accountingContext");
        }

        protected override void DisposeCore()
        {
            accountingContext.Dispose();
        }

        public async Task<IList<Account>> GetItemsAsync()
        {
            return await accountingContext.Accounts.ToListAsync();
        }

        public Task<Account> GetItemAsync(int id)
        {
            return accountingContext.Accounts
                                    .Include(x => x.User)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Account item) => await accountingContext.Accounts.AddAsync(item);

        public Task UpdateAsync(Account item) => Task.FromResult(accountingContext.Entry(item).State = EntityState.Modified);

        public async Task DeleteAsync(int id)
        {
            var account = await accountingContext.Accounts.FindAsync(id);
            if (account != null)
            {
                accountingContext.Accounts.Remove(account);
            }
        }

        public Task<int> SaveAsync() => accountingContext.SaveChangesAsync();

        public Task<int> CountAsync() => accountingContext.Accounts.CountAsync();

        public async Task<IList<Account>> GetAllByUserAsync(int userId)
        {
            return await accountingContext.Accounts
                                    .Include(x => x.User)
                                    .Where(x => x.UserId == userId)
                                    .ToListAsync();
        }

        public async Task<Account> GetByUserCurrencyAsync(int userId, int currencyId)
        {
            return await accountingContext.Accounts
                                    .Include(x => x.User)
                                    .FirstOrDefaultAsync(x => x.UserId == userId && x.CurrencyId == currencyId);
        }
    }
}
