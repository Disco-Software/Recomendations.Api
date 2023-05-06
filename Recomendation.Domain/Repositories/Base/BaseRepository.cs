using MongoDB.Driver;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Repositories.Base
{
    public abstract class BaseRepository<T, Tkey> :
        IRepository<T, Tkey>
        where T : BaseModel<Tkey>
        where Tkey : struct
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoClient _client;

        public BaseRepository(IMongoCollection<T> collection, IMongoClient client)
        {
            _collection = collection;
            _client = client;
        }

        public async Task AddAsync(T item, CancellationToken? cancellationToken)
        {
        }

        public Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Tkey id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T item, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
