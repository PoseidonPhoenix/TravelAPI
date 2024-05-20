using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.FlightDtos;
using TravelAPI.Helpers;
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
    
    public async Task<IEnumerable<Flight>> GetAllAsync(FlightQueryObject queryObject)
    {
        var flights = _context.Flights.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
        {
            flights = flights.Where(f => f.CompanyName.Contains(queryObject.CompanyName));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Departure))
        {
            flights = flights.Where(f => f.Departure.Contains(queryObject.Departure));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Arrival))
        {
            flights = flights.Where(f => f.Arrival.Contains(queryObject.Arrival));
        }

        if (queryObject.Date is not null)
        {
            flights = flights.Where(f => f.Date == queryObject.Date.Value);
        }

        if (queryObject.MaxPrice > 0)
        {
            flights = flights.Where(f => f.Price <= queryObject.MaxPrice);
        }

        if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
        {
            switch (queryObject.SortBy.ToLower())
            {
                case "companyname":
                    flights = queryObject.IsDescending ? flights.OrderByDescending(f => f.CompanyName) : flights.OrderBy(f => f.CompanyName);
                    break;
                case "departure":
                    flights = queryObject.IsDescending ? flights.OrderByDescending(f => f.Departure) : flights.OrderBy(f => f.Departure);
                    break;
                case "arrival":
                    flights = queryObject.IsDescending ? flights.OrderByDescending(f => f.Arrival) : flights.OrderBy(f => f.Arrival);
                    break;
                case "date":
                    flights = queryObject.IsDescending ? flights.OrderByDescending(f => f.Date) : flights.OrderBy(f => f.Date);
                    break;
                case "price":
                    flights = queryObject.IsDescending ? flights.OrderByDescending(f => f.Price) : flights.OrderBy(f => f.Price);
                    break;
            }
        }
        
        return await flights.ToListAsync();
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