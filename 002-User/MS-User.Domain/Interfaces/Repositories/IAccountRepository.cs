using MS_User.Domain.Entities;

namespace MS_User.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Account GetById(int _accountId);

        Account GetByUserId(int _userId);

        void Update(Account _account);
    }
}