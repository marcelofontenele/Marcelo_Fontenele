using MS_Investiments.Application.Dto;
using System.Collections.Generic;

namespace MS_Investiments.Application.Interfaces
{
    public interface IAppStockService
    {
        IEnumerable<StockDTO> GetTrends();
    }
}