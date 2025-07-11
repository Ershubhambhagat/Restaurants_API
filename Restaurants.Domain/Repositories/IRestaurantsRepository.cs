using Restaurants.Domain.Entities;
namespace Restaurants.Domain.Repositor;
public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>>GetAllAsync();
    Task<IEnumerable<Restaurant>> GetAllMatchAsync(string? SearchQuary);
    Task<Restaurant?> GetByIdAsync(int Id);
    Task<int> CreateRestaurantAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
    Task SaveChangesAsync();
}
