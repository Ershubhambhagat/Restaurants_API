using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using System.Security.Claims;

namespace Restaurants.Infrastructure.Authorization;

public class RestaurantUserClaimsPrincipalFactory(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);
        if (user.Nationaltity != null)
        {
            id.AddClaim(new Claim(AppClaimType.Nationaltity, user.Nationaltity));
        }
        if (user.DOB != null)
        {
            id.AddClaim(new Claim(AppClaimType.DOB, user.DOB.Value.ToString()));
        }
        return new ClaimsPrincipal(id);
    }
}
//here i am extending the UserClaimsPrincipalFactory and
//geting Nationaltity and DOB for Claim based access Control