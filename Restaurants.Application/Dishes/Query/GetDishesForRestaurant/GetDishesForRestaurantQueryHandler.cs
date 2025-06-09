using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;
namespace Restaurants.Application.Dishes.Query.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(
    ILogger<GetDishesForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper
    ) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        // Hare What i did 
        // We are already fetching restaurant Dishes in GetByIdAsync so not need to do again 
        // so we are extracting from restaurant.Dishes
        logger.LogInformation("Retriving Dish For Id {RestaurantId}", request.RestaurantId);
        var restaurant= await restaurantsRepository.GetByIdAsync(request.RestaurantId) ?? throw new NotFoundException($"Restaurant Id {request.RestaurantId} is not available. ");
        var result =mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        return result;
    }
}
