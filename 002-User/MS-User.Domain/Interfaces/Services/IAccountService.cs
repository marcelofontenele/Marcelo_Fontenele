using MS_User.Domain.Entities;

namespace MS_User.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Account GetByUserId(int _userId);

        void DebitOrderEmited(AccountTransaction _debit);

        void ReceiveTransfer(AccountTransaction _credit);
    }
}