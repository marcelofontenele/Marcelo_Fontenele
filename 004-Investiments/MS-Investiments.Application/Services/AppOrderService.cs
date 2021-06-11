using AutoMapper;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Services;
using System;

namespace MS_Investiments.Application.Services
{
    public class AppOrderService : IAppOrderService
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;
        private readonly IAccountService accountService;
        private readonly IAppMqPublishService mqPublisher;

        public AppOrderService(
            IMapper _mapper,
            IOrderService _orderService,
            IAccountService _accountService,
            IAppMqPublishService _mqPublisher)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.orderService = _orderService ?? throw new NullReferenceException(nameof(IOrderService));
            this.accountService = _accountService ?? throw new ArgumentNullException(nameof(IAccountService));
            this.mqPublisher = _mqPublisher ?? throw new ArgumentNullException(nameof(IAppMqPublishService));
        }

        public void OrderEmit(OrderDTO _order)
        {
            Order order = this.orderService.Insert(this.mapper.Map<Order>(_order));

            this.accountService.DebitOrderAccount(order);

            this.mqPublisher.PublishDebitAccountOrderEmit(this.mapper.Map<OrderDTO>(order));
        }
    }
}