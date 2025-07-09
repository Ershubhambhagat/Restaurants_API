
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User context is not present");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        var Nationaltity = user.FindFirst(c => c.Type == "Nationaltity")?.Value;
        var DOBstring = user.FindFirst(c => c.Type == "DOB")?.Value;
        var DOB = DOBstring == null ? (DateOnly?)null
            : DateOnly.ParseExact(DOBstring,"dd-mm-yyyy");


        return new CurrentUser(userId, email, roles, Nationaltity, DOB);
    }
}
