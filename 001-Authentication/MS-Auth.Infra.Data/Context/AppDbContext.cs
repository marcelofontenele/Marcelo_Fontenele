using Microsoft.EntityFrameworkCore;
using MS_Auth.Domain.Entities;

namespace MS_Auth.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<User>()
               .Property(x => x.Id)
               .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}