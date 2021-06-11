using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Infra.Data.Context;
using System;

namespace MS_Investiments.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public void Insert(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}