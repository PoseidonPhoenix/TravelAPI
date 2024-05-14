using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;

namespace TravelAPI.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Flight> Flights { get; set; }
}