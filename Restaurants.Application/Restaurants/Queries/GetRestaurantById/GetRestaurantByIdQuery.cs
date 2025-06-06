using MediatR;
using Restaurants.Application.Restaurants.DTOs;
namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdQuery(int Id) :IRequest<RestaurantDto?>
    {
    public int id { get; } = Id;
    }
