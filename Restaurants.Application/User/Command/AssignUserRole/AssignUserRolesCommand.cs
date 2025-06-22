

using MediatR;

namespace Restaurants.Application.User.Command.AssignUserRole;

public class AssignUserRolesCommand:IRequest
{
    public string? UserEmail { get; set; } = default;
    public string? RoleName { get; set; } = default;
}
