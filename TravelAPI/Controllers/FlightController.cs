using Microsoft.AspNetCore.Mvc;
using TravelAPI.Dtos.FlightDtos;
using TravelAPI.Interfaces;
using TravelAPI.Mappers;

namespace TravelAPI.Controllers;

[ApiController]
[Route("flights")]
public class FlightController : ControllerBase
{
    private readonly IFlightRepository _flightRepo;

    public FlightController(IFlightRepository flightRepository)
    {
        _flightRepo = flightRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var flights = await _flightRepo.GetAllAsync();
        var flightDtos = flights.Select(f => f.ToFlightDto());
        return Ok(flightDtos);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var flight = await _flightRepo.GetByIdAsync(id);

        if (flight is null)
        {
            return NotFound();
        }
        
        return Ok(flight.ToFlightDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFlightDto flightDto)
    {
        var flight = flightDto.ToFlightFromCreateFlightDto();

        await _flightRepo.CreateAsync(flight);
        
        return CreatedAtAction(nameof(GetById), new { id = flight.Id }, flight.ToFlightDto());
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFlightDto flightDto)
    {
        var flight = await _flightRepo.UpdateAsync(id, flightDto);

        if (flight is null)
        {
            return NotFound();
        }

        return Ok(flight.ToFlightDto());
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var flight = await _flightRepo.DeleteAsync(id);

        if (flight is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}