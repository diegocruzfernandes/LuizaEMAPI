using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LuizaEMAPI.Infra.Contexts;
using LuizaEMAPI.Infra.Repositories;
using LuizaEMAPI.Domain.Repositories;
using LuizaEMAPI.Infra.Transactions;
using LuizaEMAPI.Domain.Commands.Handler;

namespace LuizaEMAPI.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            //services.AddTransient - new instance
            //services.AddScoped - singleton

            services.AddScoped<LuizaEMAPIDataContext, LuizaEMAPIDataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<DepartmentCommandHandler, DepartmentCommandHandler>();
        }

       public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())          
                app.UseDeveloperExceptionPage();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();

        }
    }
}
