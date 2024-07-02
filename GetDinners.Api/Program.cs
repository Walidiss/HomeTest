using GetDinners.Api.Common.Errors;
using GetDinners.Application;
using GetDinners.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddControllers();
     builder.Services.AddSingleton<ProblemDetailsFactory, HomeTestProblemDetailsFactory>();
}
// Add services to the container.



var app = builder.Build();
{
    app.UseHttpsRedirection();

    //app.UseAuthorization();
    app.UseExceptionHandler("/error");
    app.MapControllers();

    app.Run();
}

