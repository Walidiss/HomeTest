

using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Common.Interfaces;
using GetDinners.Application.Persistance;
using GetDinners.Infrastructure.Authentication;
using GetDinners.Infrastructure.Persistance;
using GetDinners.Infrastructure.Persistance.Repositories;
using GetDinners.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GetDinners.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {            
            services
                .AddPersistance()
                .AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;

        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<HomeTestDbContext>(options =>
            //options.UseSqlServer("Server =.; Database = HomeTest; Trusted_Connection=True"));
            options.UseSqlServer("Server=localhost;Database=HomeTest;TrustServerCertificate=True;Integrated Security=True"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            return services;    

        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddScoped<IJwTokenGeneration, JwTokenGeneration>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });            


            return services;


        }
    }
}
