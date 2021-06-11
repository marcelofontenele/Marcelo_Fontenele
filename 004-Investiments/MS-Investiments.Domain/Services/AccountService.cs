using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Domain.Interfaces.Services;
using System;

namespace MS_Investiments.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository ?? throw new NullReferenceException(nameof(IAccountRepository));
        }

        public Account GetById(int _accountId)
        {
            return this.accountRepository.GetById(_accountId);
        }

        public Account GetByUserId(int _userId)
        {
            return this.accountRepository.GetByUserId(_userId);
        }

        public void ReceiveTransfer(AccountTransaction _account)
        {
            Account account = this.GetById(_account.AccountId);

            if (account == null)
            {
                throw new Exception("Não foi possível receber a transferência. Conta inexistente.");
            }

            account.AccountAmount += _account.Value;

            this.accountRepository.Update(account);
        }

        public void DebitOrderAccount(Order _order)
        {
            Account account = this.GetByUserId(_order.UserId);

            if (account == null)
            {
                throw new Exception("Não foi possível debitar o valor da ordem da conta. Conta inexistente.");
            }

            account.AccountAmount -= _order.Value * _order.Amount;

            this.accountRepository.Update(account);
        }
    }
}