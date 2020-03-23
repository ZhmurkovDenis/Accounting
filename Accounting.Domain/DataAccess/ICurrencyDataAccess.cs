using Accounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.DataAccess
{
    public interface ICurrencyDataAccess
    {
        Task<Currency> GetByIdAsync(int id);
        Task<IList<Currency>> GetAllAsync();
        Task<bool> SaveOrUpdateAsync(Currency account);
        Task<bool> DeleteAsync(int id);
    }
}
