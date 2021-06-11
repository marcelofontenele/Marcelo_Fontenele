using MS_Transaction.Domain.Entities;

namespace MS_Transaction.Domain.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        void Insert(Transfer transfer);
    }
}