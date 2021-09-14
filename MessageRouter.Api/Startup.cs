using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MessageRouter.Api.Authentication;
using MessageRouter.Application.Services;
using MessageRouter.Domain.Repositories;
using MessageRouter.Infrastructure.Repositories;

namespace MessageRouter.Api
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
            services.AddControllers();
            services.AddScoped<IEmailService, EmailService>();

            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IEmailRepository, EmailRepository>();
            services.AddSingleton<INaturalLanguageRepository, NaturalLanguageRepository>();
            services.AddSingleton<IRecipientRepository, RecipientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseServerTokenValidation();
        }
    }
}
