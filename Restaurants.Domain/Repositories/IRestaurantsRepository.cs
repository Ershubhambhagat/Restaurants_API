using Restaurants.Domain.Entities;
namespace Restaurants.Domain.Repositor;
public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>>GetAllAsync();
}
