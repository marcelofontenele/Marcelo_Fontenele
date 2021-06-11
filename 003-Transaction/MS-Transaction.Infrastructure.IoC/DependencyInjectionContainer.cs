using MS_Transaction.Application.Interfaces;
using MS_Transaction.Application.Services;
using MS_Transaction.Domain.Interfaces.Repositories;
using MS_Transaction.Domain.Interfaces.Services;
using MS_Transaction.Domain.Services;
using MS_Transaction.Infra.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IAppTransactionService, AppTransactionService>();
            services.AddScoped<IAppMqPublishService, AppMqPublishService>();

            //Domain
            services.AddScoped<ITransferService, TransferService>();

            //Data
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}