using MediatR;
using Restaurants.Domain.Contanst;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositor;
namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        IRestaurantAuthorizationServicce restaurantAuthorizationServicce) :
        IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant with Id: {request.Id} doesn't Exast");
            }
            if (!restaurantAuthorizationServicce.Authorize(restaurant, RessourceOption.Delete))
                throw new ForbidException();
          await restaurantsRepository.DeleteAsync(restaurant);
        }
    }
}