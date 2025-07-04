﻿
using FluentValidation;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant;

public class CreateRestarantCommandValidator:AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> ValidCategory = new List<string> { "Indian", "Bangali","A", "B", "1", "string" };
    public CreateRestarantCommandValidator()
    {
        RuleFor(dto => dto.Name).Length(2, 50);
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Discription is required.");
        RuleFor(dto => dto.PinCode).Length(6).WithMessage("It should be 6 Digit");

        RuleFor(dto => dto.Category).Must(ValidCategory.Contains)
            .WithMessage($"It should be from this list: {string.Join(", ", ValidCategory)}");

    }
}
