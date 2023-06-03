using Microsoft.Extensions.DependencyInjection;
using Recomendation.EventListener.Handlers;
using Recomendation.EventListener.Interfaces;
using Recomendation.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Extentions
{
    public static class EventHandlerExtentions
    {
        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            return services.AddTransient<IEventHandler<PostCreatedEvent>, PostCreatedEventHandler>();
        }
    }
}
