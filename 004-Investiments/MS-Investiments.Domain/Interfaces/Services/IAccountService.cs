using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Account GetById(int _accountId);

        Account GetByUserId(int _userId);

        void ReceiveTransfer(AccountTransaction _account);

        void DebitOrderAccount(Order _order);
    }
}