using System;
using System.Collections.Generic;

namespace find_weather_station.Models;

public partial class Station
{
    public int Id { get; set; }

    public string? WsName { get; set; }

    public string? Site { get; set; }

    public string? Portfolio { get; set; }

    public string? State { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
