using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[Controller]
[Route("api/restarants")]

public class RestaurantsController(IRestaurantsServices restaurantsServices): ControllerBase
{
    #region GetAllRastaurants
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurant =await restaurantsServices.GetAllRestaurants();
        return Ok(restaurant);
    } 
    #endregion

}

