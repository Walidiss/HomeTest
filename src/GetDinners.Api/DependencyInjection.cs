using GetDinners.Api.Common.Errors;
using GetDinners.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GetDinners.Api
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, HomeTestProblemDetailsFactory>();
            services.AddMappings();

            return services;    
        }
    }
}
