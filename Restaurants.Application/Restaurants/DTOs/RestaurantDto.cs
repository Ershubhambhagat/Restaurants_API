using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantDto
{

    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PinCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];

    #region Replace with Automapper

    //public static RestaurantDto? FromEntity(Restaurant restaurants)// everytime we are not going to map so i map one place
    //{
    //    if (restaurants == null) return null;
    //    return new RestaurantDto()
    //    {
    //        Category = restaurants.Category,
    //        Description = restaurants.Description,
    //        Id = restaurants.Id,
    //        HasDelivery = restaurants.HasDelivery,
    //        Name = restaurants.Name,
    //        City = restaurants.Address?.City,
    //        Street = restaurants.Address.Street,
    //        PinCode = restaurants.Address.PinCode,
    //        Dishes = restaurants.Dishes.Select(DishDto.FromEntity).ToList()
    //    };
    //} 
    #endregion
}
