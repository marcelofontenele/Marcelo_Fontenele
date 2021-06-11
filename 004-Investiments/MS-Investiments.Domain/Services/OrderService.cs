using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Domain.Interfaces.Services;
using System;

namespace MS_Investiments.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IStockRepository stockRepository;
        private readonly IAccountService accountService;

        public OrderService(
            IOrderRepository _orderRepository,
            IStockRepository _stockRepository,
            IAccountService _accountService)
        {
            orderRepository = _orderRepository ?? throw new NullReferenceException(nameof(IOrderRepository));
            stockRepository = _stockRepository ?? throw new NullReferenceException(nameof(IStockRepository));
            accountService = _accountService ?? throw new ArgumentNullException(nameof(IAccountService));
        }

        public Order Insert(Order order)
        {
            Stock stock = stockRepository.GetBySymbol(order.Symbol);

            if (stock == null)
            {
                throw new Exception("Ativo inválido.");
            }

            Account account = accountService.GetByUserId(order.UserId);

            if (account.AccountAmount < order.Amount * stock.CurrentPrice)
            {
                throw new Exception("Saldo insuficiente.");
            }

            order.AccountId = account.Id;
            order.Value = stock.CurrentPrice;

            orderRepository.Insert(order);

            return order;
        }
    }
}