﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
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
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.API.Controllers;

[Controller]
[Route("api/restarants")]
[Authorize]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    #region GetAllRastaurants
    [HttpGet]
    [AllowAnonymous]
    //[Authorize(Roles = UserRoles.User)]

    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll([FromQuery] GetAllRestaurantsQueary queary)
    {
        var restaurant = await mediator.Send(queary);
        return Ok(restaurant);
    }
    #endregion

    #region GetAllRastaurants_MinimumumOwnerIs2Requirement
    [HttpGet("GetAll2WithAuth")]
    [Authorize(Policy =PolicyNames.Minimumum2Requirement)]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll2WithAuth()
    {
        var restaurant = await mediator.Send(new GetAllRestaurantsQueary());
        return Ok(restaurant);
    }
    #endregion

    #region GetById
    [HttpGet("{Id}")]
    [Authorize(Policy= PolicyNames.HasNationaltity)]
   // [Authorize(Roles =UserRoles.Admin)]
    public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] int Id)
    {
        return await mediator.Send(new GetRestaurantByIdQuery(Id));
    }

    #endregion

    #region UpdateRestaurant
    [HttpPatch("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> UpdateRestaurant([FromRoute] int Id, UpdateRestaurantCommand command)
    {
        command.Id = Id;
        await mediator.Send(command);
        return NoContent();
    }

    #endregion

    #region Create Restaurant
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRastaurant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }
    #endregion
}

