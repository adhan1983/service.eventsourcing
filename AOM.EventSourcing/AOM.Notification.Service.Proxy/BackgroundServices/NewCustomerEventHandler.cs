using AOM.Customer.Domain.Events;
using AOM.Notification.Service.Proxy.EmailService.Interfaces;
using EasyNetQ;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AOM.Notification.Service.Proxy.BackgroundServices
{
    public class NewCustomerEventHandler : BackgroundService
    {        
        private IBus _bus;
        private readonly IEmailProxyClient _emailProxyClient;
        public NewCustomerEventHandler(IEmailProxyClient emailProxyClient) => _emailProxyClient = emailProxyClient;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            _bus = RabbitHutch.CreateBus(Environment.GetEnvironmentVariable("RABBITCONNECTION"));
            
            _bus.Subscribe<CustomerCreatedEvent>("CustomerNotification", SendEmail);

            while (!stoppingToken.IsCancellationRequested)            
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            
            _bus.Dispose();
        }
        private async void SendEmail(CustomerCreatedEvent customer) 
        {
            await _emailProxyClient.SendEmail(customer.Email, "CustomerCreatedEvent", "Teste do CustomerCreatedEvent");
        }
    }
}
