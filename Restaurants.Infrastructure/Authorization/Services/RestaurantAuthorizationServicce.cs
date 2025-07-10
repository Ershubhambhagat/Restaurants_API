using Restaurants.Domain.Entities;
using Microsoft.Extensions.Logging;
using Restaurants.Application.User;
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationServicce(ILogger<RestaurantAuthorizationServicce> logger,
    IUserContext userContext) : IRestaurantAuthorizationServicce
{
    public bool Authorize(Restaurant restaurants, RessourceOption ressourceOption)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Authrizing user : {user.Email} to {ressourceOption} for {restaurants.Name}");
        if (ressourceOption == RessourceOption.Read)
        {
            logger.LogInformation($"Create and Read Opration successfully Authrize for: {user.Email}");
            return true;
        }
        if (ressourceOption == RessourceOption.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation($"User Email {user.Email} is Admin and successfully Deleted {restaurants.Name}");
            return true;
        }
        if (ressourceOption == RessourceOption.Delete || ressourceOption == RessourceOption.Update && user.Id == restaurants.OwnerId)
        {
            logger.LogInformation($"User Email {user.Email} is Owner and successfully Deleted {restaurants.Name}");
            return true;
        }
        logger.LogInformation($"User Email {user.Email} is might be not Owner or Admin so can't Deleted or upate ");

        return false;

    }
}
