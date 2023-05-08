using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recomendation.Api.Controllers;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models;

namespace Recomendation.Api.Features.PostRecomendation
{
    [Route("api/[controller]")]
    public class PostRecomendationController : RecomendationsController
    {
        private readonly IPostWatchingEventRepository _postWatchingEventRepository;

        public PostRecomendationController(IPostWatchingEventRepository postWatchingEventRepository)
        {
            _postWatchingEventRepository = postWatchingEventRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostWatchingEvent>> GetAsync([FromRoute] string id)
        {
            var result = await _postWatchingEventRepository.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PostWatchingEvent>> CreateAsync([FromBody] PostWatchingEvent postWatchingEvent)
        {
            await _postWatchingEventRepository.AddAsync(postWatchingEvent, CancellationToken.None);

            return Ok(postWatchingEvent);
        }

    }
}
