using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recomendation.Domain.Configurations;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models;
using Recomendation.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Repositories
{
    internal class PostWatchingEventRepository : BaseRepository<PostWatchingEvent, string>, IPostWatchingEventRepository
    {
        public PostWatchingEventRepository(IMongoClient mongoClient, IOptions<RecommendationDatabaseSettings> options) : base(mongoClient, options.Value.DatabaseName, options.Value.PostWatchingCollectionName) { }
    }
}
