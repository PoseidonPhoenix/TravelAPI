using TravelAPI.Dtos.FlightDtos;
using TravelAPI.Models;

namespace TravelAPI.Mappers;

public static class FlightMapper
{
    public static FlightDto ToFlightDto(this Flight flight)
    {
        return new FlightDto
        {
            CompanyName = flight.CompanyName,
            Departure = flight.Departure,
            Arrival = flight.Arrival,
            Price = flight.Price,
            Date = flight.Date
        };
    }

    public static Flight ToFlightFromCreateFlightDto(this CreateFlightDto createFlightDto)
    {
        return new Flight
        {
            Id = Guid.NewGuid(),
            CompanyName = createFlightDto.CompanyName,
            Departure = createFlightDto.Departure,
            Arrival = createFlightDto.Arrival,
            Price = createFlightDto.Price,
            Date = createFlightDto.Date
        };
    }
}