using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure.Abstractions
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        ICurrencyRepository Currencies { get; }
        Task<int> SaveAsync();
    }
}
