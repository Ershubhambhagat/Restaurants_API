﻿using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.DTOs;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }

    #region Replace with Automapper
    //public static DishDto FromEntity(Dish dish)
    //{
    //    return new DishDto
    //    {
    //        Id = dish.Id,
    //        Name = dish.Name,
    //        Description = dish.Description,
    //        Price = dish.Price,
    //        KiloCalories = dish.KiloCalories
    //    };
    //}
    #endregion

}
