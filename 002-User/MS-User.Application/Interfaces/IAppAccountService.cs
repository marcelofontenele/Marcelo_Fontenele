using MS_User.Application.Dto;

namespace MS_User.Application.Interfaces
{
    public interface IAppAccountService
    {
        void DebitOrderEmited(AccountTransactionDTO _debit);
        void ReceiveTransfer(AccountTransactionDTO _credit);
    }
}