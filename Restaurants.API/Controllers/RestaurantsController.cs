using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Command.CreateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Restaurants.Queries;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurant;

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

}

