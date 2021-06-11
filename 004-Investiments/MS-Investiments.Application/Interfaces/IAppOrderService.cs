using MS_Investiments.Application.Dto;

namespace MS_Investiments.Application.Interfaces
{
    public interface IAppOrderService
    {
        void OrderEmit(OrderDTO order);
    }
}