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
        public Task HandleAsync(PostCreatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
