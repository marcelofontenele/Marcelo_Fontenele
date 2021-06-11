using MS_Investiments.Application.Interfaces;
using MS_Investiments.Application.Services;
using MS_Investiments.Domain.Interfaces.Repositories;
using MS_Investiments.Domain.Interfaces.Services;
using MS_Investiments.Domain.Services;
using MS_Investiments.Infra.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IAppMqPublishService, AppMqPublishService>();
            services.AddScoped<IAppAccountService, AppAccountService>();
            services.AddScoped<IAppOrderService, AppOrderService>();
            services.AddScoped<IAppStockService, AppStockService>();

            //Domain
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IStockService, StockService>();

            //Data
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
        }
    }
}