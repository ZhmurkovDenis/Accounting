using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataAccess.Infrastructure.Abstractions.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        Task<IList<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<int> SaveAsync();
        Task<int> CountAsync();
    }
}
