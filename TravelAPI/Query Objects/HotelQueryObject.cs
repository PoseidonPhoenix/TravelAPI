using TravelAPI.Enums;

namespace TravelAPI.Helpers;

public class HotelQueryObject
{
    public string? Location { get; set; } = null;
    public double MaxPrice { get; set; } = 0.0;
    public int Stars { get; set; } = -1;
    public HotelType? HotelType { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}