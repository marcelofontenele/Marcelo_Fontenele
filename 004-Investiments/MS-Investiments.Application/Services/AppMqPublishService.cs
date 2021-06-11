using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using MS_Investiments.Domain.Interfaces.Services;
using SharedLibrary.RabbitMQ.Interfaces;
using System;

namespace MS_Investiments.Application.Services
{
    public class AppMqPublishService : IAppMqPublishService
    {
        private readonly IMapper mapper;
        private readonly IMqPublisher mqPublisher;
        private readonly IConfiguration configuration;

        public AppMqPublishService(
            IMapper _mapper,
            IConfiguration _configuration,
            IMqPublisher _mqPublisher)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.mqPublisher = _mqPublisher ?? throw new NullReferenceException(nameof(IMqPublisher));
        }

        public void PublishDebitAccountOrderEmit(OrderDTO _order)
        {
            this.mqPublisher.Publish(
                this.configuration.GetValue<string>("MQueueDebitOrder"),
                new
                {
                    AccountId = _order.AccountId,
                    Value = _order.Total,
                    Stock = new
                    {
                        AccountId = _order.AccountId,
                        Symbol = _order.Symbol,
                        Amount = _order.Amount,
                        CurrentPrice = _order.Value
                    }
                }
            );
        }
    }
}