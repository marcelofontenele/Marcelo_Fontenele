using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MS_Investiments.Infra.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext context;

        public StockRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public Stock GetBySymbol(string symbol)
        {
            return context.Stocks.FirstOrDefault(x => x.Symbol == symbol);
        }

        public IEnumerable<Stock> GetTrends()
        {
            return context.Stocks.AsEnumerable()
                .Join(context.Orders.AsEnumerable(),
                    o => o.Symbol,
                    s => s.Symbol,
                    (s, o) => s)
                .GroupBy(s => s.Symbol,
                    (key, o) => new
                    {
                        Symbol = key,
                        o.FirstOrDefault().CurrentPrice,
                        Count = o.Count()
                    })
                .OrderByDescending(x => x.Count)
                .Take(4)
                .Select(x => new Stock
                {
                    Symbol = x.Symbol,
                    CurrentPrice = x.CurrentPrice,
                });
        }
    }
}