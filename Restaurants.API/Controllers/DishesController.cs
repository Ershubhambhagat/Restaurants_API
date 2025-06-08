using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDishAsync([FromRoute] int restaurantId ,CreateDishCommand command)
        {
            command.RestaurantId=restaurantId;//Here I bind with command
            await mediator.Send(command);
            return Created();
        }
    }
}
