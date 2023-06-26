using MediatR;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models.Aggregates;

namespace Recomendation.Api.Features.PostRecomendation.RequestHandlers.GetPostFeeds
{
    public class GetPostFeedsRequestHandler : IRequestHandler<GetPostFeeds, List<PostFeed>>
    {
        private readonly IPostFeedRepository _postFeedRepository;

        public GetPostFeedsRequestHandler(IPostFeedRepository postFeedRepository)
        {
            _postFeedRepository = postFeedRepository;
        }

        public async Task<List<PostFeed>> Handle(GetPostFeeds request, CancellationToken cancellationToken)
        {
            var postFeeds = await _postFeedRepository.GetUserPostFeedsAsync(request.AccountId);

            return postFeeds;
        }
    }
}
