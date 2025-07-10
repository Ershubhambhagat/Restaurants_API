using AutoMapper;
using MediatR;
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositor;
namespace Restaurants.Application.Restaurants.Command.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IRestaurantAuthorizationServicce restaurantAuthorizationServicce,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
            throw new NotFoundException($"Restaurant with Id: {request.Id} doesn't Exast");
        #region  //Handle by Mapper

        //restaurant.Name=request.Name;
        //restaurant.Description = request.Description;
        //restaurant.HasDelivery = request.HasDelivery; 
        #endregion
        mapper.Map(request, restaurant);

        if (!restaurantAuthorizationServicce.Authorize(restaurant, RessourceOption.Update))
            throw new ForbidException();
        await restaurantsRepository.SaveChangesAsync();
    }
}
