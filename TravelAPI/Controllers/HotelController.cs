using Microsoft.AspNetCore.Mvc;
using TravelAPI.Dtos.HotelDtos;
using TravelAPI.Interfaces;
using TravelAPI.Mappers;
using TravelAPI.Models;

namespace TravelAPI.Controllers;


[ApiController]
[Route("hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepo;

    public HotelController(IHotelRepository hotelRepository)
    {
        _hotelRepo = hotelRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hotels = await _hotelRepo.GetAllAsync();
        var hotelDtos = hotels.Select(h => h.ToHotelDto()); 
        return Ok(hotelDtos);
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var hotel = await _hotelRepo.GetByNameAsync(name);

        if (hotel is null)
        {
            return NotFound();
        }
        
        return Ok(hotel.ToHotelDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHotelDto hotelDto)
    {
        var hotel = hotelDto.ToHotelFromCreateHotelDto();
        
        await _hotelRepo.CreateAsync(hotel);
        
        return CreatedAtAction(nameof(GetByName), new { name = hotel.Name }, hotel.ToHotelDto());
    }

    [HttpPut]
    [Route("{name}")]
    public async Task<IActionResult> Update([FromRoute] string name, [FromBody] UpdateHotelDto hotelDto)
    {
        var hotel = await _hotelRepo.UpdateAsync(name, hotelDto);

        if (hotel is null)
        {
            return NotFound();
        }

        return Ok(hotel.ToHotelDto());
    }
    
    [HttpDelete]
    [Route("{name}")]
    public async Task<IActionResult> Delete([FromRoute] string name)
    {
        var hotel = await _hotelRepo.DeleteAsync(name);

        if (hotel is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}