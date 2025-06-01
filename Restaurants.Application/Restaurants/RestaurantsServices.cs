
using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsServices(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsServices> logger,IMapper mapper
    ) : IRestaurantsServices
{
    #region GetAllRestaurants
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Information");
        var restaurant = await restaurantsRepository.GetAllAsync();
        #region Mapping Restaurant to RestaurantDTO
        //var restarurantDto = restaurant.Select(r => new RestaurantDto()
        //{
        //    Category = r.Category,
        //    Description = r.Description,
        //    Id = r.Id,
        //    HasDelivery = r.HasDelivery,
        //    Name = r.Name,
        //    City = r.Address?.City,
        //    Street = r.Address.Street,
        //    PinCode = r.Address.PinCode
        //}); 
        #endregion

        //var restaurantDtos = restaurant.Select(RestaurantDto.FromEntity);
        var restaurantDtos =mapper.Map<IEnumerable<RestaurantDto>>(restaurant);//From AutoMapper
        return restaurantDtos!;
    }


    #endregion

    #region GetById
    public async Task<RestaurantDto?> GetById(int Id)
    {
        
        var restaurant = await restaurantsRepository.GetByIdAsync(Id);
        //var restaurantDtos=RestaurantDto.FromEntity(rastaurant);
        var restaurantDtos = mapper.Map<RestaurantDto>(restaurant);//From AutoMapper

        return restaurantDtos;
    } 
    #endregion
}

