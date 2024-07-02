

using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Common.Interfaces;
using GetDinners.Application.Persistance;
using GetDinners.Infrastructure.Authentication;
using GetDinners.Infrastructure.Persistance;
using GetDinners.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GetDinners.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddScoped<IJwTokenGeneration, JwTokenGeneration>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            //the authentication handler it validate the token and the user identity 
            //services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = jwtSettings.Issuer,
            //        ValidAudience = jwtSettings.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //           Encoding.UTF8.GetBytes(jwtSettings.Secret))
            //    });

            return services;

        }
    }
}
