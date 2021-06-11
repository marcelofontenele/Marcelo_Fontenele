using MS_User.Domain.Entities;

namespace MS_User.Domain.Interfaces.Services
{
    public interface IStockService
    {
        void IncludeStock(Stock _stock);
    }
}