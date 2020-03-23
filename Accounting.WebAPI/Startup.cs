using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Business.Mappers;
using Accounting.Business.Services;
using Accounting.DataAccess.DataAccess;
using Accounting.DataAccess.Infrastructure;
using Accounting.DataAccess.Infrastructure.Abstractions;
using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using Accounting.DataAccess.Infrastructure.Contexts;
using Accounting.DataAccess.Infrastructure.Repositories;
using Accounting.Domain.Business;
using Accounting.Domain.DataAccess;
using Accounting.Domain.Mappers;
using Accounting.Infastructure;
using Accounting.Infastructure.Absractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Accounting.WebAPI
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
            services
                .AddScoped(typeof(AccountingContext))
                .AddScoped<IUnitOfWork, UnitOfWork>()

                .AddSingleton<IAccountMapper, AccountMapper>()

                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<ICurrencyRepository, CurrencyRepository>()

                .AddTransient<IAccountDataAccess, AccountDataAccess>()
                .AddTransient<ICurrencyDataAccess, CurrencyDataAccess>()

                .AddTransient<ICurrencyRateClient, CurrencyRateClient>()

                .AddTransient<IAccountService, AccountService>()
                .AddTransient<ICurrencyRateService, CurrencyRateService>();

            services.AddControllers();
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
        }
    }
}
