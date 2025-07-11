
using FluentValidation;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;

public class GetAllRestaurantQuaryValidtor:AbstractValidator<GetAllRestaurantsQueary>
{
    private int[] allwoPageSize=[5,10,15,20];
    public GetAllRestaurantQuaryValidtor()
    {
        RuleFor(rs=>rs.PageNumber)
            .GreaterThanOrEqualTo(1);
        RuleFor(re => re.PageSize)
            .Must(value => allwoPageSize.Contains(value))
            .WithMessage($"Page size must be [{string.Join(",", allwoPageSize)}]");
    }
}

