﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositor;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization;
using Restaurants.Infrastructure.Authorization.Requirement;
using Restaurants.Infrastructure.Authorization.Requirement.CreatedMultipleRestaurantRequiremt;
using Restaurants.Infrastructure.Authorization.Services;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repository;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());
        services.AddScoped<IRestaurantsSeeders,RestaurantsSeeders>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository,DishesRepository>();
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RestaurantsDbContext>()
            .AddClaimsPrincipalFactory<RestaurantUserClaimsPrincipalFactory>();
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationaltity,
            builder => builder.RequireClaim(AppClaimType.Nationaltity, "India"))
            .AddPolicy(PolicyNames.AtLeast20,
            bulder => bulder.AddRequirements(new MinimumAgeRequirement(20)))
            .AddPolicy(PolicyNames.Minimumum2Requirement,
            builder => builder.AddRequirements(new OwnerCreatedMultipleRestaurantRequiremt(2)));
        services.AddScoped<IAuthorizationHandler,MinimumAgeRequirementHandler>();
        services.AddScoped<IAuthorizationHandler, OwnerCreatedMultipleRestaurantRequiremtHandler>();
        
        services.AddScoped<IRestaurantAuthorizationServicce, RestaurantAuthorizationServicce>();


    }
}
