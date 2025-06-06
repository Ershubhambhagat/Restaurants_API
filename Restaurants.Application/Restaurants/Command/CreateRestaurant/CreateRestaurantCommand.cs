using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant;

public class CreateRestaurantCommand:IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? ContectNumber { get; set; }
    public string? ContectEmail { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PinCode { get; set; }
}
