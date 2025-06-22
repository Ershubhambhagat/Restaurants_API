using MediatR;
namespace Restaurants.Application.User.Command.DeleteUserRole;
public class DeleteUserRoleCommand:IRequest
{
    public string EmailId { get; set; }
    public string RoleName { get; set; }

}
