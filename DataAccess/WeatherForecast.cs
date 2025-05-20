using System.ComponentModel.DataAnnotations;

namespace DataAccess;

public class WeatherForecast
{
  public required int Id { get; init; }
  public required DateOnly Date { get; init; }
  public required int TemperatureC { get; init; }
  [MaxLength(15)]
  public string? Summary { get; init; }
}
