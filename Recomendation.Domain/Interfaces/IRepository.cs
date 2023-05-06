using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Interfaces
{
    public interface IRepository<T, TKey>
    {
        Task AddAsync(T item, CancellationToken? cancellationToken);
        Task RemoveAsync(T item, CancellationToken? cancellationToken);
        Task<T> GetAsync(TKey id);
        Task<List<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> UpdateAsync(T item);
    }
}
