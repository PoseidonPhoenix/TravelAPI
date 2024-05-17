using Microsoft.AspNetCore.Mvc;
using TravelAPI.Dtos.DestinationDtos;
using TravelAPI.Interfaces;
using TravelAPI.Mappers;

namespace TravelAPI.Controllers;

[ApiController]
[Route("destinations")]
public class DestinationController : ControllerBase
{
    private readonly IDestinationRepository _destinationRepo;

    public DestinationController(IDestinationRepository destinationRepository)
    {
        _destinationRepo = destinationRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var destinations = await _destinationRepo.GetAllAsync();
        var destinationDtos = destinations.Select(d => d.ToDestinationDto());
        return Ok(destinationDtos);
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var destination = await _destinationRepo.GetByNameAsync(name);

        if (destination is null)
        {
            return NotFound();
        }

        return Ok(destination.ToDestinationDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDestinationDto destinationDto)
    {
        var destination = destinationDto.ToDestinationFromCreateDestinationDto();

        await _destinationRepo.CreateAsync(destination);

        return CreatedAtAction(nameof(GetByName), new { name = destination.Name }, destination.ToDestinationDto());
    }

    [HttpPut]
    [Route("{name}")]
    public async Task<IActionResult> Update([FromRoute] string name, [FromBody] UpdateDestinationDto destinationDto)
    {
        var destination = await _destinationRepo.UpdateAsync(name, destinationDto);

        if (destination is null)
        {
            return NotFound();
        }

        return Ok(destination.ToDestinationDto());
    }

    [HttpDelete]
    [Route("{name}")]
    public async Task<IActionResult> Delete([FromRoute] string name)
    {
        var destination = await _destinationRepo.DeleteAsync(name);

        if (destination is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}