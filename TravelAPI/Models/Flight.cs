namespace TravelAPI.Models;

public class Flight
{
    public Guid Id { get; init; }
    public string CompanyName { get; init; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public DateOnly Date { get; set; }
    public double Price { get; set; }
}