using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Infra.Data.Context;
using System;
using System.Linq;

namespace MS_Investiments.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;

        public AccountRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public Account GetById(int _accountId)
        {
            return context.Accounts.FirstOrDefault(a => a.Id == _accountId);
        }

        public Account GetByUserId(int _userId)
        {
            return context.Accounts.FirstOrDefault(a => a.UserId == _userId);
        }

        public void Update(Account _account)
        {
            context.Update(_account);
            context.SaveChanges();
        }
    }
}