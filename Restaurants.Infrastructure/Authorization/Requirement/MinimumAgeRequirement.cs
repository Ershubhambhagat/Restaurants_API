using Microsoft.AspNetCore.Authorization;
namespace Restaurants.Infrastructure.Authorization.Requirement;

public class MinimumAgeRequirement(int minimumAge): IAuthorizationRequirement
{
    public int MinimumAge { get; } = minimumAge;
}
