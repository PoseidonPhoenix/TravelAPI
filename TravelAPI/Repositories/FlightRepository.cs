using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.FlightDtos;
using TravelAPI.Interfaces;
using TravelAPI.Models;

namespace TravelAPI.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly ApplicationDBContext _context;

    public FlightRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        var flights = await _context.Flights.ToListAsync();
        return flights;
    }

    public async Task<Flight?> GetByIdAsync(Guid id)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);
        return flight;
    }

    public async Task<Flight> CreateAsync(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
        return flight;
    }

    public async Task<Flight?> UpdateAsync(Guid id, UpdateFlightDto updateFlightDto)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

        if (flight is null)
        {
            return null;
        }

        flight.CompanyName = updateFlightDto.CompanyName;
        flight.Departure = updateFlightDto.Departure;
        flight.Arrival = updateFlightDto.Arrival;
        flight.Date = updateFlightDto.Date;
        flight.Price = updateFlightDto.Price;

        await _context.SaveChangesAsync();
        return flight;
    }

    public async Task<Flight?> DeleteAsync(Guid id)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

        if (flight is null)
        {
            return null;
        }

        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();

        return flight;
    }
}