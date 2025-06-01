using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository;
internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository//Here i bring DbContext

{
    #region CreateRestaurantAsync
    public async Task<int> CreateRestaurantAsync(Restaurant restaurant)
    {
        dbContext.Restaurants.Add(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;

    } 
    #endregion

    #region GetAllAsync
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restarurant = await dbContext.Restaurants.ToListAsync();
        return restarurant;
    }
    #endregion

    #region GetByIdAsync
    public async Task<Restaurant?> GetByIdAsync(int Id)
    {
        return await dbContext.Restaurants
            .Include(x => x.Dishes)

            .FirstOrDefaultAsync(x => x.Id == Id);
    }
    #endregion


}
