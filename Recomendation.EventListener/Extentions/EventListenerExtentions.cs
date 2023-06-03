using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recomendation.EventListener.Interfaces;
using Recomendation.EventListener.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Extentions
{
    public static class EventListenerExtentions
    {
        public static IServiceCollection AddEventListener(this IServiceCollection services)
        {
            return services.AddSingleton<IEventListener>(provider =>
            {
                var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("AzureServiceBusConnection");

                return new ServiceBusListener(connectionString!, provider);
            });
        }
    }
}
