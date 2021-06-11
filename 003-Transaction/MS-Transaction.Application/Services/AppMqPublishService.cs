using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_Transaction.Application.Dto;
using MS_Transaction.Application.Interfaces;
using MS_Transaction.Domain.Interfaces.Services;
using SharedLibrary.RabbitMQ.Interfaces;
using System;

namespace MS_Transaction.Application.Services
{
    public class AppMqPublishService : IAppMqPublishService
    {
        private readonly IMqPublisher mqPublisher;
        private readonly IConfiguration configuration;

        public AppMqPublishService(
            IMapper _mapper,
            IConfiguration _configuration,
            IMqPublisher _mqPublisher)
        {
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.mqPublisher = _mqPublisher ?? throw new NullReferenceException(nameof(IMqPublisher));
        }

        public void PublishCreditAccount(TransferDTO transfer)
        {
            this.mqPublisher.Publish(
                this.configuration.GetValue<string>("MQueueCreditTransfer"),
                new
                {
                    AccountId = transfer.Target.Account,
                    Value = transfer.Amount
                }
            );
        }
    }
}