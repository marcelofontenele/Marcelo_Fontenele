using MS_Investiments.Application.Dto;

namespace MS_Investiments.Application.Interfaces
{
    public interface IAppMqPublishService
    {
        void PublishDebitAccountOrderEmit(OrderDTO _order);
    }
}