using Accounting.DataAccess.Infrastructure.Abstractions;
using Accounting.Domain.DataAccess;
using Accounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.DataAccess
{
    public class CurrencyDataAccess : ICurrencyDataAccess
    {
        private readonly IUnitOfWork unitOfWork;

        public CurrencyDataAccess(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("IUnitOfWork in AccountDataAccess is null");

        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Currency>> GetAllAsync()
        {
            return unitOfWork.Currencies.GetItemsAsync();
        }

        public Task<Currency> GetByIdAsync(int id)
        {
            return unitOfWork.Currencies.GetItemAsync(id);
        }

        public Task<bool> SaveOrUpdateAsync(Currency account)
        {
            throw new NotImplementedException();
        }
    }
}
