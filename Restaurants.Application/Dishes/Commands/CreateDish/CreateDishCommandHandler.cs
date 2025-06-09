
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IMapper mapper

    ) : IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating New Dish :{@DishRequest}", request.Name);
        var IsRestaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (IsRestaurant == null)
            throw new NotFoundException($"Restaurant with Id: {request.RestaurantId} and name {request.Name}does not Exist.");
        var dish = mapper.Map<Dish>(request);
        return await dishesRepository.CreateDishAsync(dish);
    }
}
