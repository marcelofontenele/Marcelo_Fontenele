using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        void Insert(Order order);
    }
}