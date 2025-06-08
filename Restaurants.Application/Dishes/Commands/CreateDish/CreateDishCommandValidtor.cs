using FluentValidation;
namespace Restaurants.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandValidtor:AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidtor()
    {
        RuleFor(Dish => Dish.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price not should be negative 😂😂😂");

        RuleFor(cal=>cal.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Calories  should be Positive 😂😂😂");
            
    }
}
