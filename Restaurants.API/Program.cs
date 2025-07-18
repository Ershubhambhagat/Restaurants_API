using Microsoft.OpenApi.Models;
using Restaurants.API.Extension;
using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    //This will construct RestaurantsSeeders before start app
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantsSeeders>();
    await seeder.Seed();

    app.UseMiddleware<ErrorHandlingMiddleWare>();
    app.UseMiddleware<RequestTimeLoggingMiddleware>();
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapGroup("api/identity")
        .WithTags("Identity")//this if for map two other endpoint to one
        .MapIdentityApi<User>();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{

    Log.Fatal(ex.Message, "Application Statup Faild ");
}
finally
{
    Log.CloseAndFlush();

}