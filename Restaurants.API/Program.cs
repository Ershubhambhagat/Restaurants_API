using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

    
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
        //This will construct RestaurantsSeeders before start app
        var scope =app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantsSeeders>();

        await seeder.Seed();

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
