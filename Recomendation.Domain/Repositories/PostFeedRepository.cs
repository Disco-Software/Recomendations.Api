using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recomendation.Domain.Configurations;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models.Aggregates;
using Recomendation.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Repositories
{
    public class PostFeedRepository : BaseRepository<PostFeed, string>, IPostFeedRepository
    {
        public PostFeedRepository(IMongoClient mongoClient, IOptions<RecommendationDatabaseSettings> options) : base(mongoClient, options.Value.DatabaseName, options.Value.PostFeedCollectionName) { }

        public async Task<List<PostFeed>> GetUserPostFeedsAsync(int accountId)
        {
            return await _collection.Find(x => x.AccountId == accountId)
                .ToListAsync();
        }
    }
}
