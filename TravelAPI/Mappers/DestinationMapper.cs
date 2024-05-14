using TravelAPI.Dtos.DestinationDtos;
using TravelAPI.Models;

namespace TravelAPI.Mappers;

public static class DestinationMapper
{
    public static DestinationDto ToDestinationDto(this Destination destination)
    {
        return new DestinationDto
        {
            Name = destination.Name,
            Country = destination.Country,
            Continent = destination.Continent,
            ImgLink = destination.ImgLink
        };
    }
    
    public static Destination ToDestinationFromCreateDestinationDto(this CreateDestinationDto createDestinationDto)
    {
        return new Destination
        {
            Name = createDestinationDto.Name,
            Country = createDestinationDto.Country,
            Continent = createDestinationDto.Continent,
            ImgLink = createDestinationDto.ImgLink
        };
    }
}