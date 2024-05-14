using System.ComponentModel.DataAnnotations;
using TravelAPI.Enums;

namespace TravelAPI.Dtos.HotelDtos;

public class CreateHotelDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public double DailyPrice { get; set; }
    [Required]
    public int Stars { get; set; }
    public HotelType HotelType { get; set; }
}