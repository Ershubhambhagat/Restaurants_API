using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public class DeleteDishesForRestaurantCommand(int RestaurantId):IRequest
{
    public int RestaurantId { get; } = RestaurantId;

}
