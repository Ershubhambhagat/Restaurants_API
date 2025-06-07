using AutoMapper;
using MediatR;
using Restaurants.Domain.Repositor;
namespace Restaurants.Application.Restaurants.Command.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
            return false;

        //Handle by Mapper
        //restaurant.Name=request.Name;
        //restaurant.Description = request.Description;
        //restaurant.HasDelivery = request.HasDelivery;

        mapper.Map(request, restaurant);
        await restaurantsRepository.SaveChangesAsync();
        return true;

    }
}
