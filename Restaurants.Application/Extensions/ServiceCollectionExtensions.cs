﻿
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.User;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)//Invoking this in Programe
    {
        services.AddMediatR(cof=>cof.RegisterServicesFromAssemblies(typeof(ServiceCollectionExtensions).Assembly));
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
            .AddFluentValidationAutoValidation();
        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}
//we are not putting services in Programe.cs just invocing there 