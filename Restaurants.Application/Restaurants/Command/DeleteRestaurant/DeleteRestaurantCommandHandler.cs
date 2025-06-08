using MediatR;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositor;


namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository) :
        IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant with Id: {request.Id} doesn't Exast");
            }
          await restaurantsRepository.DeleteAsync(restaurant);
        }
        
    }
}