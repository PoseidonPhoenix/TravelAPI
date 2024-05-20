using TravelAPI.Dtos.FlightDtos;
using TravelAPI.Helpers;
using TravelAPI.Models;

namespace TravelAPI.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetAllAsync(FlightQueryObject queryObject);
    Task<Flight?> GetByIdAsync(Guid id);
    Task<Flight> CreateAsync(Flight flight);
    Task<Flight?> UpdateAsync(Guid id, UpdateFlightDto updateFlightDto);
    Task<Flight?> DeleteAsync(Guid id);
}