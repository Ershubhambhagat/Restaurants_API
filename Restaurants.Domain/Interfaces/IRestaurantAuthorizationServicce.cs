using Restaurants.Domain.Contanst;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Interfaces
{
    public interface IRestaurantAuthorizationServicce
    {
        bool Authorize(Restaurant restaurants, RessourceOption ressourceOption);
    }
}