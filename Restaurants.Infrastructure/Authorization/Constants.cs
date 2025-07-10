namespace Restaurants.Infrastructure.Authorization;
public static class PolicyNames
{
    public const string HasNationaltity = "HasNationaltity";
    public const string AtLeast20 = "AtLeast20";
    public const string Minimumum2Requirement = "Minimumum2Requirement";
}
public static class AppClaimType
{
    public const string Nationaltity = "Nationaltity";
    public const string DOB = "DOB";
}