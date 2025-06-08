using MediatR;

namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant;
public class DeleteRestaurantCommand(int id):IRequest
{
    public int Id { get; set; }=id;
}