using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Dtos.DestinationDtos;

public class CreateDestinationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Continent { get; set; }
    [Required]
    public string ImgLink { get; set; }
}