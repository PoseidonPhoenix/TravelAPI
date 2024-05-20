namespace TravelAPI.Helpers;

public class FlightQueryObject
{
    public string? CompanyName { get; set; } = null;
    public string? Departure { get; set; } = null;
    public string? Arrival { get; set; } = null;
    public DateOnly? Date { get; set; } = null;
    public double MaxPrice { get; set; } = 0.0;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}