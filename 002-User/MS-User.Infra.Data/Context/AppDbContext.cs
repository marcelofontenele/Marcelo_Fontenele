using Microsoft.EntityFrameworkCore;
using MS_User.Domain.Entities;

namespace MS_User.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Account>()
                .Property(e => e.AccountAmount)
                .HasColumnType("decimal")
                .HasDefaultValue(0)
                .HasPrecision(10);

            modelBuilder
                .Entity<Stock>()
                .Property(e => e.CurrentPrice)
                .HasColumnType("decimal")
                .HasDefaultValue(0)
                .HasPrecision(10);

            base.OnModelCreating(modelBuilder);
        }
    }
}