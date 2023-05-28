using Azure.Messaging.ServiceBus;
using Recomendation.EventListener.Interfaces;
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

        public ServiceBusListener(string connectionString)
        {
            _serviceBusClient = new ServiceBusClient(connectionString);
            _serviceBusProcessor = _serviceBusClient.CreateProcessor("post-created-event", "recommendation-service-subscription", new ServiceBusProcessorOptions());
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body} from subscription.");

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
