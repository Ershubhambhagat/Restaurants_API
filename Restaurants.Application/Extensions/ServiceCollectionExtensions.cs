
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)//Invoking this in Programe
    {
        services.AddScoped<IRestaurantsServices ,RestaurantsServices>();

    }
}
