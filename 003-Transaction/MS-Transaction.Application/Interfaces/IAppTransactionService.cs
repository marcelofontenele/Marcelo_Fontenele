using MS_Transaction.Application.Dto;

namespace MS_Transaction.Application.Interfaces
{
    public interface IAppTransactionService
    {
        void Transfer(TransferDTO transfer);
    }
}