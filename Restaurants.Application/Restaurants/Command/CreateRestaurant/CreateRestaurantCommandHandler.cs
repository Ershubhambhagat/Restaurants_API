using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurants.Application.User;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper,IRestaurantsRepository restaurantsRepository,IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
    {
        #region Create Restaurant
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var currentUser= userContext.GetCurrentUser();
            logger.LogInformation($"Createing a new restaurant by Email{currentUser?.Email} and Id {currentUser?.Id}");
            var Restaurant = mapper.Map<Restaurant>(request);
            Restaurant.OwnerId = currentUser.Id;
            int id = await restaurantsRepository.CreateRestaurantAsync(Restaurant);
            return id;
        }
        #endregion
    }
}
