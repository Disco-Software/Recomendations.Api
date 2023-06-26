using AutoMapper;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models.Aggregates;
using Recomendation.EventListener.Interfaces;
using Recomendation.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Handlers
{
    public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IPostFeedRepository _repository;

        public PostCreatedEventHandler(
            IMapper mapper, 
            IPostFeedRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task HandleAsync(PostCreatedEvent @event)
        {
            var userPostFeed = _mapper.Map<PostFeed>(@event);
            
            await _repository.AddAsync(userPostFeed, CancellationToken.None);

            foreach (var follower in @event.Account.UserFollowerDtos)
            {
                var postFeed = _mapper.Map<PostFeed>(@event);

                postFeed.AccountId = follower.AccountId;

                await _repository.AddAsync(postFeed, CancellationToken.None);
            }
            
            foreach (var following in @event.Account.UserFollowingDtos)
            {
                var postFeed = _mapper.Map<PostFeed>(@event);

                postFeed.AccountId = following.AccountId;

                await _repository.AddAsync(postFeed, CancellationToken.None);
            }
        }
    }
}
