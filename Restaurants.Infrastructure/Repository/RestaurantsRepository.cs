using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository;
internal class RestaurantsRepository(RestaurantsDbContext dbContext) //Here i bring DbContext
    : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restarurant = await dbContext.Restaurants.ToListAsync();
        return restarurant;
    }
}
