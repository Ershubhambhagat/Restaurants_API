using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantsSeeders(RestaurantsDbContext dbContext) : IRestaurantsSeeders
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())// Checking connection 
        {
            if(!dbContext.Restaurants.Any())// checking any data is there
            {
                var Restaurants = GetRestaurants();// if data is not there
                dbContext.Restaurants.AddRange(Restaurants);//Insert Data
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.Roles.Any())
            {
                var roles= GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }



    #region GetRoles Seed
    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
            new(UserRoles.User),
            new(UserRoles.Owner),
            new(UserRoles.Admin)
            ];
        return roles;
    } 
    #endregion
    #region GetRestaurants Seed
    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
             {
                Name = "KFC",
                Category = "Fast Food",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                 ContectEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new ()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M,
                    },

                    new ()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M,
                    },
                ],
                Address = new ()
                {
                    City = "London",
                    Street = "Cork St 5",
                    PinCode = "WC2N 5DU"
                }
            },
            new ()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContectEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "London",
                    Street = "Boots 193",
                    PinCode = "W1F 8SR"
                }
            }
        ];
        return restaurants;
    } 
    #endregion
}
