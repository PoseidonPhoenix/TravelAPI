using Microsoft.AspNetCore.Mvc;
using TravelAPI.Dtos.DestinationDtos;
using TravelAPI.Helpers;
using TravelAPI.Models;

namespace TravelAPI.Interfaces;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> GetAllAsync(DestinationQueryObject queryObject);
    Task<Destination?> GetByNameAsync(string name);
    Task<Destination> CreateAsync(Destination destination);
    Task<Destination?> UpdateAsync(string name, UpdateDestinationDto updateDestinationDto);
    Task<Destination?> DeleteAsync(string name);
}