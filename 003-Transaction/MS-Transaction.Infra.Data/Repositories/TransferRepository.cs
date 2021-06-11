using MS_Transaction.Domain.Entities;
using MS_Transaction.Domain.Interfaces.Repositories;
using MS_Transaction.Infra.Data.Context;
using System;

namespace MS_Transaction.Infra.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AppDbContext context;

        public TransferRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public void Insert(Transfer transfer)
        {
            context.Transfers.Add(transfer);
            context.SaveChanges(true);
        }
    }
}