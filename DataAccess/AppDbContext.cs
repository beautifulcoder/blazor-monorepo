using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> _options) : DbContext(_options)
{
  public DbSet<WeatherForecast> WeatherForecasts { get; set; }
  public DbSet<Counter> Counters { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<WeatherForecast>().ToTable("weather_forecasts");
    modelBuilder.Entity<Counter>().ToTable("counters");

    modelBuilder.Entity<WeatherForecast>().HasKey(w => w.Id);
    modelBuilder.Entity<Counter>().HasKey(c => c.Id);

    modelBuilder.Entity<WeatherForecast>().HasData(
      new WeatherForecast { Id = 1, Date = new DateOnly(2025, 5, 11), TemperatureC = 20, Summary = "Warm" },
      new WeatherForecast { Id = 2, Date = new DateOnly(2023, 5, 12), TemperatureC = 15, Summary = "Cool" },
      new WeatherForecast { Id = 3, Date = new DateOnly(2023, 5, 13), TemperatureC = 10, Summary = "Cold" },
      new WeatherForecast { Id = 4, Date = new DateOnly(2023, 5, 14), TemperatureC = 25, Summary = "Hot" },
      new WeatherForecast { Id = 5, Date = new DateOnly(2023, 5, 15), TemperatureC = 30, Summary = "Very Hot" }
    );

    modelBuilder.Entity<Counter>().HasData(
      new Counter { Id = 1, CurrentCount = 0 }
    );
  }
}
