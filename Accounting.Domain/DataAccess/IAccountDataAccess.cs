using Accounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.DataAccess
{
    public interface IAccountDataAccess
    {
        Task<Account> GetByIdAsync(int id);
        Task<IList<Account>> GetAllAsync();
        Task<bool>  SaveOrUpdateAsync(Account account);
        Task<bool> DeleteAsync(int id);
        Task<Account> GetByUserCurrencyAsync(int userId, int currencyId);
        Task<IList<Account>> GetAllByUserAsync(int userId);
    }
}
