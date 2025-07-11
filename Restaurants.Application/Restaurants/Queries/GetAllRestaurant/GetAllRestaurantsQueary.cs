using MediatR;
using Restaurants.Application.Restaurants.DTOs;
namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;
public class GetAllRestaurantsQueary :IRequest<IEnumerable<RestaurantDto>>
{
    public string? SerchQuary { get; set; }
    public int PageSize { get; set; } = 5;
    public int PageNumber { get; set; } = 5;

}