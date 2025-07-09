using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.User;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Infrastructure.Authorization.Requirement;

internal class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
    IUserContext userContext
    ) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser();
        if (currentUser == null)
        {
            throw new NotFoundException($"No user Found or You are not authrize to this API Call");
        }

        logger.LogInformation($"User Email:{currentUser.Email} and DOB :{currentUser.DOB}");

        if (currentUser.DOB == null)
        {
            logger.LogInformation($"User : {currentUser.Email} is null DOB");
            context.Fail();
            return Task.CompletedTask;
        }
        if (currentUser.DOB.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            logger.LogInformation("Authrize your Age");
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
            logger.LogInformation("you are not Age authrize");
            logger.LogInformation($"User : {currentUser.Email} is not vilad DOB to access this api");
        }
        return Task.CompletedTask;
    }
}
