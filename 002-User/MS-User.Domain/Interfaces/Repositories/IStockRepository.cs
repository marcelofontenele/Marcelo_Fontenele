using MS_User.Domain.Entities;

namespace MS_User.Domain.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Stock GetUserStock(Stock _stock);
        void Insert(Stock _stock);
        void Update(Stock _stock);
    }
}