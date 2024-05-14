using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;
using TravelAPI.Interfaces;
using TravelAPI.Repositories;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();