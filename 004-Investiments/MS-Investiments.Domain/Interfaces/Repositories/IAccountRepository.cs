using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Account GetById(int _accountId);

        Account GetByUserId(int _userId);

        void Update(Account _account);
    }
}