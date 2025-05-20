
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsServices(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsServices> logger
    ) : IRestaurantsServices
{
    #region GetAllRestaurants
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Information");
        var restaurant = await restaurantsRepository.GetAllAsync();
        return restaurant;
    }


    #endregion

    #region GetById
    public async Task<Restaurant?> GetById(int Id)
    {
        var rastaurant = await restaurantsRepository.GetByIdAsync(Id);
        return rastaurant;
    } 
    #endregion
}

