

using MediatR;

namespace Restaurants.Application.User.Command;

public class UpdateUserDetailsCommand:IRequest
{
    public DateOnly? DOB { get; set; }
    public string Nationaltity { get; set; }
}
