using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Query.GetDishByIdForRestaurant;
using Restaurants.Application.Dishes.Query.GetDishesForRestaurant;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDishAsync([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;//Here I bind with command
            await mediator.Send(command);
            return Created();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }
        [HttpGet("{DishId}")]
        public async Task<ActionResult<DishDto>> GetAllForRestaurant([FromRoute] int restaurantId, [FromRoute] int DishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, DishId));
            return Ok(dish);
        }
    }
}
