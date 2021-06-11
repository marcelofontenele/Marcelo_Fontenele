using Microsoft.EntityFrameworkCore;
using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Account>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder
                .Entity<Account>()
                .Property(x => x.Created)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Account>()
                .Property(e => e.AccountAmount)
                .HasColumnType("decimal")
                .HasPrecision(10)
                .HasDefaultValue(0);

            modelBuilder
               .Entity<Order>()
               .Property(x => x.Created)
               .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Order>()
                .Property(e => e.Value)
                .HasColumnType("decimal")
                .HasPrecision(10)
                .HasDefaultValue(0);

            modelBuilder
               .Entity<Stock>()
               .Property(e => e.CurrentPrice)
               .HasColumnType("decimal")
               .HasPrecision(10)
               .HasDefaultValue(0);

            base.OnModelCreating(modelBuilder);
        }
    }
}