using MediatR;
using Restaurants.Application.Dishes.DTOs;
namespace Restaurants.Application.Dishes.Query.GetDishesForRestaurant;

public class GetDishesForRestaurantQuery(int RestaurantsId) : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; } = RestaurantsId;
}

