using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

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

}

