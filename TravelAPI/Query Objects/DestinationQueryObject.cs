namespace TravelAPI.Helpers;

public class DestinationQueryObject
{
    public string? Country { get; set; } = null;
    public string? Continent { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}