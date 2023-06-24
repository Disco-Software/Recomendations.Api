using MediatR;
using Recomendation.Domain.Models.Aggregates;

namespace Recomendation.Api.Features.PostRecomendation.RequestHandlers.GetPostFeeds
{
    public class GetPostFeeds : IRequest<List<PostFeed>>
    {
        public GetPostFeeds(int accountId)
        {
            AccountId = accountId;
        }

        public int AccountId { get; }
    }
}
