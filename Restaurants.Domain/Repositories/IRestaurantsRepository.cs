using Restaurants.Domain.Entities;
namespace Restaurants.Domain.Repositor;
public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>>GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int Id);
    Task<int> CreateRestaurantAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
}
