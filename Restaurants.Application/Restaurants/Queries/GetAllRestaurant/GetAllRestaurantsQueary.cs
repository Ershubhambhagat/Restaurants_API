using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.DTOs;
namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;
public class GetAllRestaurantsQueary :IRequest<PageResult<RestaurantDto>>
{
    public string? SerchQuary { get; set; }
    public int PageSize { get; set; } = 5;
    public int PageNumber { get; set; } = 5;

}