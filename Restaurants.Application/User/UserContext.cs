
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User;


public interface IUserContext
{
    CurentUser? GetCurentUser();
}
public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurentUser? GetCurentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User Context not resent ");
        }
        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }
        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(xs => xs.Value);

        return new CurentUser(userId, email, roles);

    }
}
