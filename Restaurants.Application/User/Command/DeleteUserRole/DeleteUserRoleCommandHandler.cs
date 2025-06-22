using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.User.Command.DeleteUserRole;
public class DeleteUserRoleCommandHandler (
    UserManager<Domain.Entities.User>userManager,
    RoleManager<IdentityRole>roleManager
    ): IRequestHandler<DeleteUserRoleCommand>
{
    public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.EmailId)
            ?? throw new NotFoundException($"User Email {request.EmailId} not found in database;");
        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException($"Role  :{request.RoleName} for Email: {request.EmailId} not found in database;");
        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}