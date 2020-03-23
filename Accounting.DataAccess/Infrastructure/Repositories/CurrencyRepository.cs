using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using Accounting.DataAccess.Infrastructure.Contexts;
using Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure.Repositories
{
    public class CurrencyRepository : Disposable, ICurrencyRepository
    {
        private readonly AccountingContext accountingContext;

        public CurrencyRepository(AccountingContext accountingContext)
        {
            this.accountingContext = accountingContext ?? throw new ArgumentNullException("accountingContext");

        }
        protected override void DisposeCore()
        {
            accountingContext.Dispose();
        }


        public async Task<IList<Currency>> GetItemsAsync()
        {
            return await accountingContext.Currencies.ToListAsync();
        }

        public Task<Currency> GetItemAsync(int id)
        {
            return accountingContext.Currencies
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Currency item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Currency item)
        {
            throw new NotImplementedException();
        }
    }
}
