using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MS_User.Application.Dto;
using MS_User.Application.Interfaces;
using Newtonsoft.Json;
using SharedLibrary.RabbitMQ.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS_User.WebApi.Host
{
    public class DataCollectorHost : IHostedService
    {
        private readonly IAppAccountService appAccountService;
        private readonly IAppStockService appStockService;
        private readonly IMqSubscriber subscriber;
        private readonly IConfiguration configuration;

        public DataCollectorHost(
            IAppUserService _appUserService,
            IAppAccountService _appAccountService,
            IAppStockService _appStockService,
            IMqSubscriber subscriber,
            IConfiguration configuration)
        {
            appAccountService = _appAccountService ?? throw new ArgumentNullException(nameof(IAppAccountService));
            appStockService = _appStockService ?? throw new ArgumentNullException(nameof(IAppStockService));
            this.subscriber = subscriber ?? throw new ArgumentNullException(nameof(IMqSubscriber));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe(this.configuration.GetValue<string>("MQueueCreditTransfer"), ProcessTransferMessage);
            subscriber.Subscribe(this.configuration.GetValue<string>("MQueueDebitOrder"), ProcessOrderMessage);

            return Task.CompletedTask;
        }

        private void ProcessTransferMessage(string message)
        {
            this.appAccountService.ReceiveTransfer(JsonConvert.DeserializeObject<AccountTransactionDTO>(message));
        }

        private void ProcessOrderMessage(string message)
        {
            var transaction = JsonConvert.DeserializeObject<AccountTransactionDTO>(message);

            this.appAccountService.DebitOrderEmited(transaction);

            this.appStockService.IncludeStock(transaction.Stock);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}