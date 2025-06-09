using Microsoft.EntityFrameworkCore.Diagnostics;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository;

public class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository

{
    #region CreateDishAsync
    public async Task<int> CreateDishAsync(Dish Entity)
    {
        await dbContext.AddAsync(Entity);
        await dbContext.SaveChangesAsync();
        return Entity.Id;
    }
    #endregion

    #region DeleteAsync
    public async Task DeleteAsync(IEnumerable<Dish> Entity)
    {
        dbContext.RemoveRange(Entity);
        await dbContext.SaveChangesAsync();
    } 
    #endregion
}