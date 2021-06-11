using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Repositories;
using MS_User.Domain.Interfaces.Services;
using System;

namespace MS_User.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository ?? throw new NullReferenceException(nameof(IStockRepository));
        }

        public void IncludeStock(Stock _stock)
        {
            Stock stock = this.stockRepository.GetUserStock(_stock);

            if (stock == null)
            {
                this.stockRepository.Insert(_stock);
                return;
            }

            stock.Amount += _stock.Amount;

            this.stockRepository.Update(stock);
        }
    }
}