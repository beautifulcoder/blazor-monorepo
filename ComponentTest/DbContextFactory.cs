using Bunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentTest;

public class DbContextFactory<TContext>(
  DbContextOptions<TContext> _options)
  : IDbContextFactory<TContext> where TContext : DbContext
{
  public TContext CreateDbContext() =>
    (TContext)Activator.CreateInstance(
      typeof(TContext), _options)!
    ?? throw new InvalidOperationException("Could not create DbContext");
}

public static class DbContextFactoryExtensions
{
  public static IServiceCollection AddDbContextFactory<TContext>(
    this TestServiceProvider services,
    DbContextOptions<TContext> options)
    where TContext : DbContext =>
    services.AddSingleton<IDbContextFactory<TContext>>(
      new DbContextFactory<TContext>(options));
}
