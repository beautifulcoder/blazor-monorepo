using BlazorApp.Components.Pages;
using Bunit;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ComponentTest;

public class WeatherTests : TestContext
{
  private readonly DbContextOptions<AppDbContext> _options =
    new DbContextOptionsBuilder<AppDbContext>()
      .UseInMemoryDatabase("TestDatabase")
      .Options;

  [Fact]
  public void WeatherComponentRendersForecastCorrectly()
  {
    using var context = new AppDbContext(_options);
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var forecast = new WeatherForecast
    {
      Id = 10,
      Date = new DateOnly(2025, 5, 13),
      TemperatureC = 25,
      Summary = "Warm"
    };

    context.WeatherForecasts.Add(forecast);
    context.SaveChanges();

    Services.AddDbContextFactory(_options);

    var cut = RenderComponent<Weather>();
    var lastForecast = cut.Find("tbody tr:last-child");

    lastForecast.MarkupMatches(
    """
      <tr>
        <td>5/13/2025</td>
        <td>25</td>
        <td>76</td>
        <td>Warm</td>
      </tr>
    """);
  }

  [Fact]
  public void WeatherComponentRendersHeaderCorrectly()
  {
    using var context = new AppDbContext(_options);
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Services.AddDbContextFactory(_options);

    var cut = RenderComponent<Weather>();
    var header = cut.Find("thead tr");

    header.MarkupMatches(
    """
      <tr>
        <th>Date</th>
        <th aria-label="Temperature in Celsius">Temp. (C)</th>
        <th aria-label="Temperature in Fahrenheit">Temp. (F)</th>
        <th>Summary</th>
      </tr>
    """);
  }
}
