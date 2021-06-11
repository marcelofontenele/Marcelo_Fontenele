using MS_Investiments.Application.Dto;

namespace MS_Investiments.Application.Interfaces
{
    public interface IAppAccountService
    {
        void ReceiveTransfer(AccountTransactionDTO _credit);
    }
}