using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.DestinationDtos;
using TravelAPI.Helpers;
using TravelAPI.Interfaces;
using TravelAPI.Models;

namespace TravelAPI.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly ApplicationDBContext _context;

    public DestinationRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Destination>> GetAllAsync(DestinationQueryObject queryObject)
    {
        var destinations = _context.Destinations.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryObject.Country))
        {
            destinations = destinations.Where(d => d.Country.Contains(queryObject.Country));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Continent))
        {
            destinations = destinations.Where(d => d.Continent.Contains(queryObject.Continent));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
        {
            switch (queryObject.SortBy.ToLower())
            {
                case "name":
                    destinations = queryObject.IsDescending ? destinations.OrderByDescending(d => d.Name) : destinations.OrderBy(d => d.Name);
                    break;
                case "country":
                    destinations = queryObject.IsDescending ? destinations.OrderByDescending(d => d.Country) : destinations.OrderBy(d => d.Country);
                    break;
                case "continent":
                    destinations = queryObject.IsDescending ? destinations.OrderByDescending(d => d.Continent) : destinations.OrderBy(d => d.Continent);
                    break;
            }
        }
        
        return await destinations.ToListAsync();
    }

    public async Task<Destination?> GetByNameAsync(string name)
    {
        var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Name == name);
        return destination;
    }

    public async Task<Destination> CreateAsync(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
        await _context.SaveChangesAsync();
        return destination;
    }

    public async Task<Destination?> UpdateAsync(string name, UpdateDestinationDto updateDestinationDto)
    {
        var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Name == name);

        if (destination is null)
        {
            return null;
        }

        destination.Name = updateDestinationDto.Name;
        destination.Country = updateDestinationDto.Country;
        destination.Continent = updateDestinationDto.Continent;
        destination.ImgLink = updateDestinationDto.ImgLink;

        await _context.SaveChangesAsync();
        return destination;
    }

    public async Task<Destination?> DeleteAsync(string name)
    {
        var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Name == name);

        if (destination is null)
        {
            return null;
        }

        _context.Destinations.Remove(destination);
        await _context.SaveChangesAsync();
        
        return destination;
    }
}