using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using SharedLibrary.RabbitMQ;
using SharedLibrary.RabbitMQ.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;

namespace SharedLibrary.Startup
{
    public static class Startup
    {
        public static IServiceCollection AddShareServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog(new NLogProviderOptions
                {
                    CaptureMessageTemplates = true,
                    CaptureMessageProperties = true
                });
            });

            services.AddSwaggerGen(options =>
            {
                string appName = Configuration.GetValue<string>("AppName") ?? "MS-APP";

                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = appName,
                    Description = appName,
                    Version = "v1"
                });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                        Configuration.GetValue<string>("TokenSecretKey"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddRabbitMqConnectionServices(this IServiceCollection services)
        {
            services.AddSingleton<IMqConnectionProvider>(new MqConnectionProvider());

            return services;
        }

        public static IServiceCollection AddRabbitMqPublisherServices(this IServiceCollection services)
        {
            services.AddScoped<IMqPublisher>(x => new MqPublisher(x.GetService<IMqConnectionProvider>()));

            return services;
        }

        public static IServiceCollection AddRabbitMqSubscriberServices(this IServiceCollection services)
        {
            services.AddSingleton<IMqSubscriber>(x => new MqSubscriber(x.GetService<IMqConnectionProvider>()));

            return services;
        }

        public static IServiceCollection AddDbContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddDbContext<T>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
            );

            return services;
        }

        public static IApplicationBuilder UseShareMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", "v1");
                options.DocExpansion(DocExpansion.List);
                options.DocExpansion(DocExpansion.None);
            });

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}