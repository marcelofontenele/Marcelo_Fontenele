using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS_User.Application.Mapper;
using MS_User.Infra.Data.Context;
using MS_User.WebApi.Host;
using SharedLibrary.Startup;

namespace MS_User.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(new AuthorizeFilter(
                    new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build()));
            })
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddCors();

            services.AddControllers();

            services.AddShareServices(this.Configuration);

            services.AddDbContext<AppDbContext>(this.Configuration);

            services.AddAutoMapper(typeof(AutoMapperObject).Assembly);

            services.AddDependencyInjection();

            services.AddRabbitMqConnectionServices();

            services.AddRabbitMqSubscriberServices();

            services.AddHostedService<DataCollectorHost>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseShareMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}