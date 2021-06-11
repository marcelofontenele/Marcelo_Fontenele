using MS_Transaction.Domain.Entities;

namespace MS_Transaction.Domain.Interfaces.Services
{
    public interface ITransferService
    {
        void RegisterTransfer(Transfer transfer);
    }
}