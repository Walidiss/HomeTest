using GetDinners.Api;
using GetDinners.Api.Common.Errors;
using GetDinners.Application;
using GetDinners.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

}
// Add services to the container.



var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}

