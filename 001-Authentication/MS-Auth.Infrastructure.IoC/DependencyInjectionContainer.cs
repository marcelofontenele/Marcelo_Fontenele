using MS_Auth.Application.Interfaces;
using MS_Auth.Application.Services;
using MS_Auth.Domain.Interfaces.Repositories;
using MS_Auth.Domain.Interfaces.Services;
using MS_Auth.Domain.Services;
using MS_Auth.Infra.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IAppAuthenticationService, AppAuthenticationService>();

            //Domain
            services.AddScoped<IUserService, UserService>();

            //Data
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}