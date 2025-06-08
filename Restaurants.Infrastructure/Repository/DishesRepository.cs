using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository;

public class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository

{
    public async Task<int> CreateDishAsync(Dish Entity)
    {
        await dbContext.AddAsync(Entity);
        await dbContext.SaveChangesAsync();
        return Entity.Id;
    }
}