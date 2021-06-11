using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Repositories;
using MS_User.Infra.Data.Context;
using System;
using System.Linq;

namespace MS_User.Infra.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext context;

        public StockRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public Stock GetUserStock(Stock _stock)
        {
            return context.Stocks.FirstOrDefault(a => a.Symbol == _stock.Symbol && a.AccountId == _stock.AccountId);
        }

        public void Insert(Stock _stock)
        {
            context.Add(_stock);
            context.SaveChanges();
        }

        public void Update(Stock _stock)
        {
            context.Update(_stock);
            context.SaveChanges();
        }
    }
}