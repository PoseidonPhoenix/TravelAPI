﻿using TravelAPI.Dtos.HotelDtos;
using TravelAPI.Helpers;
using TravelAPI.Models;

namespace TravelAPI.Interfaces;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllAsync(HotelQueryObject queryObject);
    Task<Hotel?> GetByNameAsync(string name);
    Task<Hotel> CreateAsync(Hotel hotel);
    Task<Hotel?> UpdateAsync(string name, UpdateHotelDto updateHotelDto);
    Task<Hotel?> DeleteAsync(string name);
}