using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Repositories;
using MS_User.Infra.Data.Context;
using System;
using System.Linq;

namespace MS_User.Infra.Data.Repositories
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
            return (from account in context.Accounts
                    where account.User.Id == _userId
                    select new Account
                    {
                        AccountAmount = account.AccountAmount,
                        Positions = (from stock in context.Stocks where stock.AccountId == account.Id select stock).ToList()
                    }).FirstOrDefault();
        }

        public void Update(Account _account)
        {
            context.Update(_account);
            context.SaveChanges();
        }
    }
}