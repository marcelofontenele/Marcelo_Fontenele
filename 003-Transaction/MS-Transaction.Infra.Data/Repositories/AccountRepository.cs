using MS_Transaction.Domain.Entities;
using MS_Transaction.Domain.Interfaces.Repositories;
using MS_Transaction.Infra.Data.Context;
using System;
using System.Linq;

namespace MS_Transaction.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;

        public AccountRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public bool HasAccount(Transfer transfer)
        {
            return this.context.Accounts.Any(
            x =>
                x.Id == int.Parse(transfer.Target.Account)
             && x.User.CPF == transfer.Origin.CPF.Trim());
        }
    }
}