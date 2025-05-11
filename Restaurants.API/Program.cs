using Microsoft.EntityFrameworkCore;
using Restaurants.API.Controllers;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Persistence;
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        //using Restaurants.Infrasturacture.Extensions1
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        //builder.Services.AddDbContext<RestaurantsDbContext>(option =>
        //{
        //    option.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantsDb"));
        //});
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

      

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}