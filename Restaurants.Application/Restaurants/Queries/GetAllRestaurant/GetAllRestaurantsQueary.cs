using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;
public class GetAllRestaurantsQueary :IRequest<IEnumerable<RestaurantDto>>{}
