using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace MS_Transaction.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly IConfiguration configuration;

        public AppDbContextFactory(
            IConfiguration _configuration)
        {
            configuration = _configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}