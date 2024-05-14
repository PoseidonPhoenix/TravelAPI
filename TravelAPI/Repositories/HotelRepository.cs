using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.HotelDtos;
using TravelAPI.Interfaces;
using TravelAPI.Models;

namespace TravelAPI.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDBContext _context;
    
    public HotelRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        var hotels =  await _context.Hotels.ToListAsync();
        return hotels;
    }

    public async Task<Hotel?> GetByNameAsync(string name)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Name == name);
        return hotel;
    }

    public async Task<Hotel> CreateAsync(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task<Hotel?> UpdateAsync(string name, UpdateHotelDto updateHotelDto)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Name == name);
        
        if (hotel is null)
        {
            return null;
        }

        hotel.Name = updateHotelDto.Name;
        hotel.Location = updateHotelDto.Location;
        hotel.Stars = updateHotelDto.Stars;
        hotel.DailyPrice = updateHotelDto.DailyPrice;
        hotel.HotelType = updateHotelDto.HotelType;

        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task<Hotel?> DeleteAsync(string name)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Name == name);

        if (hotel is null)
        {
            return null;
        }

        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }
}