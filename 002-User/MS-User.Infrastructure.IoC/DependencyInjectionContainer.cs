using MS_User.Application.Interfaces;
using MS_User.Application.Services;
using MS_User.Domain.Interfaces.Repositories;
using MS_User.Domain.Interfaces.Services;
using MS_User.Domain.Services;
using MS_User.Infra.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IAppStockService, AppStockService>();
            services.AddScoped<IAppAccountService, AppAccountService>();
            services.AddScoped<IAppUserService, AppUserService>();

            //Domain
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IAccountService, AccountService>();

            //Data
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}