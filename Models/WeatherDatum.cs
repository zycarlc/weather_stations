using System;
using System.Collections.Generic;

namespace find_weather_station.Models;

public partial class WeatherDatum
{
    public int Id { get; set; }

    public int? StationId { get; set; }

    public DateTime? Timestamp { get; set; }

    public decimal? AirtInst { get; set; }

    public double? GhiInist { get; set; }

    public decimal? AvgWm2 { get; set; }

    public decimal? AvgAirtemp { get; set; }

    public decimal? WsAvg { get; set; }

    public decimal? WdAvg { get; set; }
}
