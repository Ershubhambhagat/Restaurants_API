using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.User.Command.AssignUserRole;

public class AssignUserRolesCommandHandler(
    UserManager<Domain.Entities.User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRolesCommand>
{
    public async Task Handle(AssignUserRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException($" User Email : {request.UserEmail} not Found ,{nameof(User)}");

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException($"{nameof(IdentityRole)} :{request.RoleName}Not found. ");
        await userManager.AddToRoleAsync(user, role.Name!);
    }
}
