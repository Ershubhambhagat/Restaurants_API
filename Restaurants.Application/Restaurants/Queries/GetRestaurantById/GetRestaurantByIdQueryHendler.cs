using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHendler (
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository,
        ILogger<GetRestaurantByIdQueryHendler> logger
        )
        
        : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        #region GetById
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.id)
               ?? throw new NotFoundException($"Restaurant with Id: {request.id} doesn't Exist");
            
            var restaurantDtos = mapper.Map<RestaurantDto>(restaurant);//From AutoMapper
            return restaurantDtos;
        }
        #endregion
    }
}
