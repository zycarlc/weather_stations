using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using find_weather_station.Models;

namespace find_weather_station.db;

public partial class WeatherContext : DbContext
{
    public WeatherContext()
    {
    }

    public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<WeatherDatum> WeatherData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=weather");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Station>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stations");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 7)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(10, 7)
                .HasColumnName("longitude");
            entity.Property(e => e.Portfolio).HasColumnName("portfolio");
            entity.Property(e => e.Site).HasColumnName("site");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.WsName).HasColumnName("ws_name");
        });

        modelBuilder.Entity<WeatherDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("weather_data");

            entity.Property(e => e.AirtInst)
                .HasPrecision(10, 2)
                .HasColumnName("airt_inst");
            entity.Property(e => e.AvgAirtemp)
                .HasPrecision(10, 2)
                .HasColumnName("avg_airtemp");
            entity.Property(e => e.AvgWm2)
                .HasPrecision(10, 1)
                .HasColumnName("avg_wm2");
            entity.Property(e => e.GhiInist).HasColumnName("ghi_inist");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.StationId).HasColumnName("station_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.WdAvg)
                .HasPrecision(10, 1)
                .HasColumnName("wd_avg");
            entity.Property(e => e.WsAvg)
                .HasPrecision(10, 3)
                .HasColumnName("ws_avg");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

// reverse database command line
// dotnet ef dbcontext scaffold "Host="localhost";port="5432";Database="weather"" Npgsql.EntityFrameworkCore.PostgreSQL --context-dir db --output-dir Models