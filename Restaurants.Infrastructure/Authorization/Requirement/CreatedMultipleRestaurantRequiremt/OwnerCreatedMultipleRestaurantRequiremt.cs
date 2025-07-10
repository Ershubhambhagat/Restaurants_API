
using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization.Requirement.CreatedMultipleRestaurantRequiremt
{
    public class OwnerCreatedMultipleRestaurantRequiremt(int MinimumRestaurantCreated) : IAuthorizationRequirement
    {
        public int MinimumRestaurantCreated { get; } = MinimumRestaurantCreated;
    }
}