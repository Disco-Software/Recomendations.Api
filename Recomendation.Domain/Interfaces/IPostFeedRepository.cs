using Recomendation.Domain.Models.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Interfaces
{
    public interface IPostFeedRepository : IRepository<PostFeed, string>
    {
        public Task<List<PostFeed>> GetUserPostFeedsAsync(int accountId);
    }
}
