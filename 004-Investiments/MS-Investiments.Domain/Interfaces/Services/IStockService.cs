using MS_Investiments.Domain.Entities;
using System.Collections.Generic;

namespace MS_Investiments.Domain.Interfaces.Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetTrends();
    }
}