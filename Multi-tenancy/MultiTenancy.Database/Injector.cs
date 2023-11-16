using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MultiTenancy.Database;

public static class Injector
{
    public static IServiceCollection AddDatabase(this IServiceCollection services) =>
        services
            // Adds pooling context factory as a Singleton service
            .AddPooledDbContextFactory<Context>(
                o =>
                {
                    o.UseNpgsql("Server=localhost;Port=5432;Database=MultiTenancy;User Id=postgres;Password=jerico Include Error Detail=true;");
                    o.LogTo(Console.WriteLine);
                    o.EnableDetailedErrors();
                })
            // Adds custom context factory
            .AddScoped<TenantBaseContextScopedFactory>()
            // Adds context to get injected from our Scoped factory
            .AddScoped<Context>(
                p => p
                    .GetRequiredService<TenantBaseContextScopedFactory>()
                    .CreateDbContext()
            );
}
