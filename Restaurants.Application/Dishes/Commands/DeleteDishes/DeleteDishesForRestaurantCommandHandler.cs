using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositor;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository, IRestaurantAuthorizationServicce restaurantAuthorizationServicce,
        IDishesRepository dishesRepository)
        : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            string message = $"Deleting dishes for this restaurant Id {request.RestaurantId}";
            logger.LogWarning(message);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId) ?? throw new NotFoundException($"Restaurant with  Id {request.RestaurantId} Not found in DB.");
            if (!restaurant.Dishes.Any())
            {
                throw new NotFoundException($"Restaurant with  Id {request.RestaurantId} found in DB but no any Dish is there to delete.");
            }
            if (!restaurantAuthorizationServicce.Authorize(restaurant, RessourceOption.Delete))
                throw new ForbidException();
            await dishesRepository.DeleteAsync(restaurant.Dishes);
        }
    }
}
