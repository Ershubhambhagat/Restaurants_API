using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Command.CreateRestaurant;
using Restaurants.Application.Restaurants.Command.DeleteRestaurant;
using Restaurants.Application.Restaurants.Command.UpdateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Queries;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurant;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

[Controller]
[Route("api/restarants")]

public class RestaurantsController(IMediator mediator) : ControllerBase
{
    #region GetAllRastaurants
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurant = await mediator.Send(new GetAllRestaurantsQueary());
        return Ok(restaurant);
    }
    #endregion

    #region GetById
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(Id));
        if (restaurant == null)
            return NotFound();
        return Ok(restaurant);
    }

    #endregion

    #region UpdateRestaurant
    [HttpPatch("{Id}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int Id, UpdateRestaurantCommand command)
    {
        command.Id = Id;
        var IsUpdated = await mediator.Send(command);
        if (IsUpdated)
            return NoContent();
        return NotFound();
    }

    #endregion

    #region Create Restaurant
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        int id = await mediator.Send(createRestaurantCommand);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    #endregion

    #region DeleteRastaurant 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRastaurant([FromRoute] int id) 
    {
        var IsDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
        if (IsDeleted)
            return NoContent();
        return NotFound();
    }
#endregion
}

