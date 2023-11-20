using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Schedules.API.Models;
using Sidearm.V3.Core.Models;
using Sidearm.V3.EntityFramework.Converters;

namespace Schedules.API.Database;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

        modelBuilder.Entity<Schedule>()
            .HasData(
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Sidearmu",
                    Title = "The Sidearm Schedule",
                    Note = "Sidearm u note",
                    CategoryId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #1",
                    Note = "Oklahoma #1",
                    CategoryId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now, ModifiedAt = null
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #2",
                    Note = "Oklahoma #2",
                    CategoryId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now
                }
            );
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        foreach (EntityEntry<ITrackableEntity> entry in
                 ChangeTracker.Entries<ITrackableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(ct);
    }
    
    /// <summary>
    /// Convert all date to utc
    /// </summary>
    /// <param name="configurationBuilder"></param>
    protected sealed override void ConfigureConventions(
        ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>()
            .HaveConversion(typeof(DateTimeToDateTimeUtcConverter));
    }
}
