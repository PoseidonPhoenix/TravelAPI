namespace TravelAPI.Dtos.FlightDtos;

public class UpdateFlightDto
{
    public string CompanyName { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public DateOnly Date { get; set; }
    public double Price { get; set; }
}