using TravelAPI.Enums;

namespace TravelAPI.Dtos.HotelDtos;

public class UpdateHotelDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double DailyPrice { get; set; }
    public int Stars { get; set; }
    public HotelType HotelType { get; set; }
    public string ImgLink { get; set; }
}