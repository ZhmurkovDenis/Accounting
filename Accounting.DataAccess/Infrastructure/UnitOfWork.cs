using Accounting.DataAccess.Infrastructure.Abstractions;
using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using Accounting.DataAccess.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure
{
    public sealed class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly AccountingContext accountingContext;
        public UnitOfWork(AccountingContext accountingContext,
                          IAccountRepository accountRepository,
                          ICurrencyRepository currencyRepository)
        {
            this.accountingContext = accountingContext ?? throw new ArgumentNullException("accountingContext");
            this.Accounts = accountRepository ?? throw new ArgumentNullException("accountRepository");
            this.Currencies = currencyRepository ?? throw new ArgumentNullException("currencyRepository");

        }

        public IAccountRepository Accounts { get; }

        public ICurrencyRepository Currencies { get; }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        protected override void DisposeCore()
        {
            accountingContext.Dispose();
        }
    }
}
