using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant
{
    internal class GetAllRestaurantsQueryHandler 
        (ILogger<GetAllRestaurantsQueryHandler>logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository        
        ): IRequestHandler<GetAllRestaurantsQueary, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQueary request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Information");
            var restaurant = await restaurantsRepository.GetAllAsync();
            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurant);//From AutoMapper
            return restaurantDtos!;
        }
    }
}
