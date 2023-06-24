using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recomendation.Api.Features.PostRecomendation.RequestHandlers.GetPostFeeds;
using Recomendation.Domain.Models.Aggregates;

namespace Recomendation.Api.Features.PostRecomendation
{
    [Route("post")]
    [ApiController]
    public class PostRecomendationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostRecomendationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostFeed>>> GetPostFeedsAsync([FromQuery] int accountId) =>
            await _mediator.Send(new GetPostFeeds(accountId));
    }
}
