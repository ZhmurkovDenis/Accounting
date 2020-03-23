using Accounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure.Abstractions.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IList<Account>> GetAllByUserAsync(int userId);
        Task<Account> GetByUserCurrencyAsync(int userId, int currencyId);
    }
}
