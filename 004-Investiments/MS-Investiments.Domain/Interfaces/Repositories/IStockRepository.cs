using MS_Investiments.Domain.Entities;
using System.Collections.Generic;

namespace MS_Investiments.Domain.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Stock GetBySymbol(string symbol);

        IEnumerable<Stock> GetTrends();
    }
}