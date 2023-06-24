using AutoMapper;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Recomendation.Domain.Models.Aggregates;
using Recomendation.EventListener.Interfaces;
using Recomendation.Events.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Listeners
{
    public class ServiceBusListener : IEventListener
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusProcessor _serviceBusProcessor;
        private readonly IServiceProvider _serviceProvider;

        public ServiceBusListener(
            string connectionString, 
            IServiceProvider serviceProvider)
        {
            _serviceBusClient = new ServiceBusClient(connectionString);
            _serviceBusProcessor = _serviceBusClient.CreateProcessor("post-created-event", "recommendation-service-subscription", new ServiceBusProcessorOptions());
            _serviceProvider = serviceProvider;
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            var handler = _serviceProvider.GetRequiredService<IEventHandler<PostCreatedEvent>>();

            var @event = JsonConvert.DeserializeObject<PostCreatedEvent>(args.Message.Body.ToString());

            await handler.HandleAsync(@event);

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        public async Task RunAsync()
        {
            _serviceBusProcessor.ProcessMessageAsync += MessageHandler;
            _serviceBusProcessor.ProcessErrorAsync += ErrorHandler; 
            
            await _serviceBusProcessor.StartProcessingAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _serviceBusProcessor.StopProcessingAsync();

            await _serviceBusProcessor.DisposeAsync();
            await _serviceBusClient.DisposeAsync();
        }
    }
}
