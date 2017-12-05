using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using LuizaEM.Infra.Context;
using LuizaEM.Infra.Transactions;
using LuizaEM.Domain.Repositories;
using LuizaEM.Infra.Repositories;
using LuizaEM.Domain.Services;
using LuizaEM.AppService;
using System.Text;

namespace LuizaEM.Api
{
    public class Startup
    {
        private const string ISSUER = "CC42F707";
        private const string AUDIENCE = "A15308A8E455";
        private const string SECRET_KEY = "AA9A03F3-0CE2-403B-A597-194E584D7ED1";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();


            //services.AddTransient - new instance
            //services.AddScoped - singleton
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAppService, UserAppService>();

            services.AddTransient<IDepartmentAppService, DepartmentAppService>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeAppService, EmployeeAppService>();


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
