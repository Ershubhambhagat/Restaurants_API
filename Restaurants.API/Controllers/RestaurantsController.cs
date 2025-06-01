using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.API.Controllers;

[Controller]
[Route("api/restarants")]

public class RestaurantsController(IRestaurantsServices restaurantsServices) : ControllerBase
{
    #region GetAllRastaurants
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurant = await restaurantsServices.GetAllRestaurants();
        return Ok(restaurant);
    }
    #endregion

    [HttpGet ("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        var restaurant = await restaurantsServices.GetById(Id);
        if (restaurant == null)
            return NotFound();
        return Ok(restaurant);
    }
    #region Create Restaurant
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestrarantDto)
    {
        if (!ModelState.IsValid) 
        { 
            return BadRequest(ModelState);
        }
        int id = await restaurantsServices.Create(createRestrarantDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    } 
    #endregion

}

