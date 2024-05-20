using TravelAPI.Dtos.HotelDtos;
using TravelAPI.Models;

namespace TravelAPI.Mappers;

public static class HotelMapper
{
    public static HotelDto ToHotelDto(this Hotel hotel)
    {
        return new HotelDto
        {
            Name = hotel.Name,
            Location = hotel.Location,
            DailyPrice = hotel.DailyPrice,
            Stars = hotel.Stars,
            HotelType = hotel.HotelType,
            ImgLink = hotel.ImgLink
        };
    }

    public static Hotel ToHotelFromCreateHotelDto(this CreateHotelDto createHotelDto)
    {
        return new Hotel
        {
            Name = createHotelDto.Name,
            Location = createHotelDto.Location,
            DailyPrice = createHotelDto.DailyPrice,
            Stars = createHotelDto.Stars,
            HotelType = createHotelDto.HotelType,
            ImgLink = createHotelDto.ImgLink
        };
        
    }
}