using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using Newtonsoft.Json;
using SharedLibrary.RabbitMQ.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS_Investiments.WebApi.Host
{
    public class DataCollectorHost : IHostedService
    {
        private readonly IAppAccountService appAccountService;
        private readonly IMqSubscriber subscriber;
        private readonly IConfiguration configuration;

        public DataCollectorHost(
            IAppAccountService _appAccountService,
            IMqSubscriber subscriber,
            IConfiguration configuration)
        {
            appAccountService = _appAccountService ?? throw new ArgumentNullException(nameof(IAppAccountService));
            this.subscriber = subscriber ?? throw new ArgumentNullException(nameof(IMqSubscriber));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe(this.configuration.GetValue<string>("MQueueCreditTransfer"), ProcessTransferMessage);

            return Task.CompletedTask;
        }

        private void ProcessTransferMessage(string message)
        {
            this.appAccountService.ReceiveTransfer(JsonConvert.DeserializeObject<AccountTransactionDTO>(message));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}