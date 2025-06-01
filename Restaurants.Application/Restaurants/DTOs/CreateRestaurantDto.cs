using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.DTOs
{
    public class CreateRestaurantDto
    {
        [StringLength(50,MinimumLength =2,ErrorMessage ="Name should be more then 3 latter")]
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
}
