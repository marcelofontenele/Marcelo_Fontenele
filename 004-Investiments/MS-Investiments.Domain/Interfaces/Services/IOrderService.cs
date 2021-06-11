using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Order Insert(Order order);
    }
}