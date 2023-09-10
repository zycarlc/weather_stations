using find_weather_station.Models;
using find_weather_station.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace weather_station.Controllers;

[ApiController]
[Route("[controller]")]
public class StationsController : ControllerBase
{
    WeatherContext _context;

    public StationsController(WeatherContext context)
    {
        _context = context;
   
    }

    [HttpGet]
    public IEnumerable<Station> Get()
    {
        return _context.Stations
            .AsNoTracking()
            .ToList();
    }
}
