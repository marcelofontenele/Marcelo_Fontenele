using Microsoft.EntityFrameworkCore;
using MS_Transaction.Domain.Entities;

namespace MS_Transaction.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Origin> TransferOrigins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

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
               .Entity<User>()
               .Property(x => x.Id)
               .ValueGeneratedNever();

            modelBuilder
                .Entity<User>()
                .Property(x => x.Created)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Transfer>()
                .Property(e => e.Amount)
                .HasColumnType("decimal")
                .HasDefaultValue(0)
                .HasPrecision(10);

            modelBuilder
                .Entity<Transfer>()
                .Property(x => x.Created)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Transfer>()
                .Property(x => x.Amount)
                .HasDefaultValue(0);

            modelBuilder
               .Entity<Origin>()
               .Property(x => x.Created)
               .HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}