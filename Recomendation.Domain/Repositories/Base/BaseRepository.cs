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
        where Tkey : class
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(
            IMongoClient client,
            string databaseName,
            string collectionName)
        {
            _collection = client.GetDatabase(databaseName)
                .GetCollection<T>(collectionName);
        }

        public virtual async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(item, default, cancellationToken);
        }

        public virtual Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetAsync(Tkey id)
        {
           return await _collection.Find(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public virtual async Task RemoveAsync(Tkey id, CancellationToken cancellationToken = default)
        {
            await _collection.DeleteOneAsync(t => t.Id == id, cancellationToken);
        }

        public virtual async Task UpdateAsync(T item)
        {
            await _collection.ReplaceOneAsync(i => i.Id == item.Id, item);
        }
    }
}
