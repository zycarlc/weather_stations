using find_weather_station.Models;
using find_weather_station.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace weather_data.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherDataController : ControllerBase
{
    WeatherContext _context;

    public WeatherDataController(WeatherContext context)
    {
        _context = context;
   
    }

    [HttpGet]
    public IEnumerable<WeatherDatum> Get()
    {
        return _context.WeatherData
            .AsNoTracking()
            .ToList();
    }
}
