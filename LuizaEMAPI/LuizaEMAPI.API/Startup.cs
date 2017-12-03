using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LuizaEMAPI.Infra.Contexts;
using LuizaEMAPI.Infra.Repositories;
using LuizaEMAPI.Domain.Repositories;
using LuizaEMAPI.Infra.Transactions;
using LuizaEMAPI.Domain.Services;
using LuizaEMAPI.AppService;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using LuizaEMAPI.Domain.Common;
using LuizaEMAPI.API.Security;
using System;

namespace LuizaEMAPI.API
{
    public class Startup
    {
        private const string ISSUER = "CC42F707";
        private const string AUDIENCE = "A15308A8E455";
        private const string SECRET_KEY = "AA9A03F3-0CE2-403B-A597-194E584D7ED1";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY)); 
             
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
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
                //33 min
                options.AddPolicy("User", policy => policy.RequireClaim("LuizaEMAPI", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("LuizaEMAPI", "Admin"));
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SiniginCredential = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
            

            //services.AddTransient - new instance
            //services.AddScoped - singleton

            services.AddScoped<LuizaEMAPIDataContext, LuizaEMAPIDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IDepartmentAppService, DepartmentAppService>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAppService, UserAppService>();
            

            
        }

       public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())          
                app.UseDeveloperExceptionPage();

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
            {
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

            Runtime.ConnectionString = Configuration.GetConnectionString("ConnStrLocal");
        }
    }
}
 