using MS_Transaction.Domain.Entities;
using MS_Transaction.Domain.Interfaces.Repositories;
using MS_Transaction.Domain.Interfaces.Services;
using System;

namespace MS_Transaction.Domain.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository transferRepository;
        private readonly IAccountRepository accountRepository;

        public TransferService(
            ITransferRepository _transferRepository,
            IAccountRepository _accountRepository)
        {
            transferRepository = _transferRepository ?? throw new NullReferenceException(nameof(ITransferRepository));
            accountRepository = _accountRepository ?? throw new NullReferenceException(nameof(IAccountRepository));
        }

        public void RegisterTransfer(Transfer transfer)
        {
            if (!this.accountRepository.HasAccount(transfer))
            {
                throw new Exception("A conta com o CPF informado não existe.");
            }

            this.transferRepository.Insert(transfer);

            //SQS
        }
    }
}