using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.User.Command.AssignUserRole;
using Restaurants.Application.User.Command.UpdateUserDetails;
using Restaurants.Domain.Contanst;

namespace Restaurants.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("UpdateUserDetails")]
    #region UpdateUserDetails
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    } 
    #endregion

    [HttpPost("AssignUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    #region AssignUserRole
    public async Task<IActionResult> AssignUserRole(AssignUserRolesCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    } 
    #endregion
}
