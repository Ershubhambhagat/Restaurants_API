
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsServices(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsServices> logger
    ) : IRestaurantsServices
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Information");
        var restaurant = await restaurantsRepository.GetAllAsync();
        return restaurant;
    }
}

