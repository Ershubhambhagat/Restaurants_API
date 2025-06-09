
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Query.GetDishesForRestaurant;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;
using System.Numerics;

namespace Restaurants.Application.Dishes.Query.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQueryHandler (
    ILogger <GetDishByIdForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository
    ,IMapper mapper
    )
    
    : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retriving Dish by {RestaurantId} and Dish Id {DishId}.",request.RestaurantId , request.DishId);
        var restaurant= await restaurantsRepository.GetByIdAsync(request.RestaurantId) ?? throw new NotFoundException($"Restaurant Id {request.RestaurantId} is not Exist So Dish Id : {request.DishId} is also not available.");
        var dish = restaurant.Dishes.FirstOrDefault(x => x.Id == request.DishId) ??
            throw new NotFoundException($"Restaurant Found 💁‍♂️ \n RestaurantId: {restaurant.Id} and Restaurant Name {restaurant.Name} \n but Dish Id {request.DishId} not Found.(❁´◡`❁). ");
       return mapper.Map<DishDto>(dish);

    }
}
