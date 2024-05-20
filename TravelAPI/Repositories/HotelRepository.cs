using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Dtos.HotelDtos;
using TravelAPI.Helpers;
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
    
    public async Task<IEnumerable<Hotel>> GetAllAsync(HotelQueryObject queryObject)
    {
        var hotels =  _context.Hotels.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(queryObject.Location))
        {
            hotels = hotels.Where(h => h.Location.Contains(queryObject.Location));
        }

        if (queryObject.MaxPrice > 0)
        {
            hotels = hotels.Where(h => h.DailyPrice <= queryObject.MaxPrice);
        }

        if (queryObject.Stars > -1)
        {
            hotels = hotels.Where(h => h.Stars == queryObject.Stars);
        }

        if (queryObject.HotelType is not null)
        {
            hotels = hotels.Where(h => h.HotelType == queryObject.HotelType.Value);
        }

        if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
        {
            switch (queryObject.SortBy.ToLower())
            {
                case "location":
                    hotels = queryObject.IsDescending ? hotels.OrderByDescending(h => h.Location) : hotels.OrderBy(h => h.Location);
                    break;
                case "dailyprice":
                    hotels = queryObject.IsDescending ? hotels.OrderByDescending(h => h.DailyPrice) : hotels.OrderBy(h => h.DailyPrice);
                    break;
                case "stars":
                    hotels = queryObject.IsDescending ? hotels.OrderByDescending(h => h.Stars) : hotels.OrderBy(h => h.Stars);
                    break;
                case "hoteltype":
                    hotels = queryObject.IsDescending ? hotels.OrderByDescending(h => h.HotelType) : hotels.OrderBy(h => h.HotelType);
                    break;
            }
        }
        
        return await hotels.ToListAsync();
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
        hotel.ImgLink = updateHotelDto.ImgLink;

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