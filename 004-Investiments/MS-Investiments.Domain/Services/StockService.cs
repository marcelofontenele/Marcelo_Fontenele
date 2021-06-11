using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MS_Investiments.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;

        public StockService(
            IOrderRepository _orderRepository,
            IAccountRepository _accountRepository,
            IStockRepository _stockRepository)
        {
            stockRepository = _stockRepository ?? throw new NullReferenceException(nameof(IStockRepository));
        }

        public IEnumerable<Stock> GetTrends()
        {
            return stockRepository.GetTrends();
        }
    }
}