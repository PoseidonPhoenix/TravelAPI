namespace TravelAPI.Models;

public class Hotel
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double DailyPrice { get; set; }
    public int Stars { get; set; }
    public HotelType HotelType { get; set; }
}

public enum HotelType
{
    AccommodationOnly,
    HalfBoard,
    FullBoard
}