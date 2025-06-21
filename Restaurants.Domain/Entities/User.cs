
using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities;

public class User:IdentityUser
{
    public DateOnly? DOB { get; set; }
    public string Nationaltity { get; set; }
}
