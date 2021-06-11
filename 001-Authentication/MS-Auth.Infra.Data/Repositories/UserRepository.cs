using MS_Auth.Domain.Entities;
using MS_Auth.Domain.Interfaces.Repositories;
using MS_Auth.Infra.Data.Context;
using System;
using System.Linq;

namespace MS_Auth.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext _context)
        {
            context = _context ?? throw new NullReferenceException(nameof(AppDbContext));
        }

        public User Get(User user)
        {
            return context.Users.FirstOrDefault(
                u => 
                u.Login == user.Login 
                && u.Password == user.Password
                && u.Active
            );
        }
    }
}