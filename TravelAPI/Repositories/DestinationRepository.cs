using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.DestinationDtos;
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
    
    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        var destinations = await _context.Destinations.ToListAsync();
        return destinations;
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