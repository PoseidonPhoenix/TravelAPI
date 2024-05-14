using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Dtos.FlightDtos;

public class CreateFlightDto
{
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Departure { get; set; }
    [Required]
    public string Arrival { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public double Price { get; set; }
}