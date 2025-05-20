using Bunit;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using CounterComponent = BlazorApp.Components.Pages.Counter;

namespace ComponentTest;

public class CounterTests : TestContext
{
  private readonly DbContextOptions<AppDbContext> _options =
    new DbContextOptionsBuilder<AppDbContext>()
      .UseInMemoryDatabase("TestDatabase")
      .Options;

  [Fact]
  public void CounterComponentRendersCorrectly()
  {
    using var context = new AppDbContext(_options);
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Services.AddDbContextFactory(_options);

    var cut = RenderComponent<CounterComponent>();

    cut.MarkupMatches(
    """
      <h1>Counter</h1>
      <p role="status">Current count: 0</p>
      <button class="btn btn-primary">
        Click me
      </button>
    """);
  }

  [Fact]
  public void CounterComponentIncrementsCount()
  {
    using var context = new AppDbContext(_options);
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Services.AddDbContextFactory(_options);

    var cut = RenderComponent<CounterComponent>();

    cut.Find("button").Click();
    var status = cut.Find("p[role='status']");

    status.MarkupMatches(
    """
      <p role="status">Current count: 1</p>
    """);
  }
}
