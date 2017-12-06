using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using Microsoft.Extensions.Configuration;
using LuizaEM.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using LuizaEM.Api.Security;
using LuizaEM.Infra.Service;

namespace LuizaEM.Api
{
    public class Startup
    {
        //Secret Keys for JWT
        private const string ISSUER = "CC42F707";
        private const string AUDIENCE = "A15308A8E455";
        private const string SECRET_KEY = "AA9A03F3-0CE2-403B-A597-194E584D7ED1";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            //read file appsetting.json with configurations
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Block all Routers
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("LuizaEMAPI", "Admin"));
                options.AddPolicy("User", policy => policy.RequireClaim("LuizaEMAPI", "User"));
               
            });            

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SiniginCredential = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
            

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

            services.AddTransient<IEmailService, EmailService>();

            services.AddSwaggerDocumentation();           

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {           
            app.UseSwaggerDocumentation();

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }  

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {   //With values ​​in true, an Identity server is not required
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();

            //Add connections string existent in file appsetting.json
            Runtime.ConnectionString = Configuration.GetConnectionString("ConnStrLocal");
        }
    }
}
