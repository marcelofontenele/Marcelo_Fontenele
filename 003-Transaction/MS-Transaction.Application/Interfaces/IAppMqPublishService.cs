using MS_Transaction.Application.Dto;

namespace MS_Transaction.Application.Interfaces
{
    public interface IAppMqPublishService
    {
        void PublishCreditAccount(TransferDTO transfer);
    }
}