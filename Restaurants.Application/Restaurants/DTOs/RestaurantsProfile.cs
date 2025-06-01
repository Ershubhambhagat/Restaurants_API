using AutoMapper;
using Restaurants.Domain.Entities;


namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantsProfile:Profile


{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant, RestaurantDto>()
        .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
        .ForMember(d => d.PinCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PinCode))
        .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
        .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));



    }

}
