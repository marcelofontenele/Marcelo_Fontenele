using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Repositories;
using MS_User.Domain.Interfaces.Services;
using System;

namespace MS_User.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository ?? throw new NullReferenceException(nameof(IAccountRepository));
        }

        public Account GetByUserId(int _userId)
        {
            return this.accountRepository.GetByUserId(_userId);
        }

        public void DebitOrderEmited(AccountTransaction _debit)
        {
            Account account = this.accountRepository.GetById(_debit.AccountId);

            if (account == null)
            {
                throw new Exception("Não foi possível debitar a ordem emitida. Conta inexistente.");
            }

            account.AccountAmount -= _debit.Value;

            this.accountRepository.Update(account);
        }

        public void ReceiveTransfer(AccountTransaction _credit)
        {
            Account account = this.accountRepository.GetById(_credit.AccountId);

            if (account == null)
            {
                throw new Exception("Não foi possível receber a transferência. Conta inexistente.");
            }

            account.AccountAmount += _credit.Value;

            this.accountRepository.Update(account);
        }
    }
}