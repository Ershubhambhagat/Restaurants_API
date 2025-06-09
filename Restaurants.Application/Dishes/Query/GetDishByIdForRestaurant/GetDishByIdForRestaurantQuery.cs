using MediatR;
using Restaurants.Application.Dishes.DTOs;
namespace Restaurants.Application.Dishes.Query.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(int RestaurantId, int DishId) :IRequest<DishDto>
{
    public int RestaurantId { get; }=RestaurantId;
    public int DishId { get; }=DishId;

}
