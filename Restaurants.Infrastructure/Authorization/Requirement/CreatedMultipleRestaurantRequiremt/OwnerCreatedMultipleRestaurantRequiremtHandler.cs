using Microsoft.AspNetCore.Authorization;
using Restaurants.Application.User;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;

namespace Restaurants.Infrastructure.Authorization.Requirement.CreatedMultipleRestaurantRequiremt
{
    internal class OwnerCreatedMultipleRestaurantRequiremtHandler(IRestaurantsRepository restaurantsRepository
        , IUserContext userContext
        ) : AuthorizationHandler<OwnerCreatedMultipleRestaurantRequiremt>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OwnerCreatedMultipleRestaurantRequiremt requirement)
        {
            var currUser = userContext.GetCurrentUser();
            var allRes = await restaurantsRepository.GetAllAsync();
            int CountOfRestaurant = allRes.Count(r => r.OwnerId == currUser!.Id);
            if (CountOfRestaurant >= requirement.MinimumRestaurantCreated)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
                throw new NotFoundException($"Your Id :{currUser!.Email} Should have At least 2 Restaurant " +
                    $"To use this API. \n Now You Have Only :{CountOfRestaurant} restaurant. ");

            }
                
        }
    }
}
