using System.Collections.Generic;
using System.Linq;

namespace MS_User.Application.Dto
{
    public class PositionDTO
    {
        public decimal AccountAmount { get; set; }
        public IList<StockDTO> Positions { get; set; }
        public decimal ConsolidatedAmount => this.Positions.Sum(p => p.Amount * p.CurrentPrice) + this.AccountAmount;
    }
}