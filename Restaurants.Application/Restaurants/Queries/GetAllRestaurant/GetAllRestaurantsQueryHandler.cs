using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositor;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQueary, PageResult<RestaurantDto>>
    {
        public async Task<PageResult<RestaurantDto>> Handle(GetAllRestaurantsQueary request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Information");
            var (restaurant, TotalCount) = await restaurantsRepository.GetAllMatchAsync(
                request.SerchQuary,
                request.PageSize,
                request.PageNumber);
            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurant);//From AutoMapper
            var result = new PageResult<RestaurantDto>(restaurantDtos, TotalCount, request.PageSize, request.PageNumber);

            return result!;
        }
    }
}
