using MS_Transaction.Domain.Entities;

namespace MS_Transaction.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        bool HasAccount(Transfer transfer);
    }
}