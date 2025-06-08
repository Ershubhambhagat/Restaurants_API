using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IDishesRepository
{
    Task<int> CreateDishAsync(Dish Entity);
}
