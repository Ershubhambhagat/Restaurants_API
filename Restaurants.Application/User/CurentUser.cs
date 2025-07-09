namespace Restaurants.Application.User;
public record CurrentUser(
    string Id,
    string Email,
    IEnumerable<string> Roles,
    string Nationaltity ,
    DateOnly? DOB)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}