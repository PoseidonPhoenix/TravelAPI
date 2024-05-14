using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models;

[PrimaryKey(nameof(Name))]
public class Destination
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Continent { get; set; }
    public string ImgLink { get; set; }
}