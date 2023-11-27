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
                    Title = "The Sidearm Schedule #1",
                    Note = "Sidearm u note / category #1",
                    CategoryId = Guid.Parse("402ab577-379f-4e42-86ea-9ecf2e454dd5"),
                    CreatedAt = DateTime.Now
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #1",
                    Note = "Oklahoma #1",
                    CategoryId = Guid.Parse("402ab577-379f-4e42-86ea-9ecf2e454dd5"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = null
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #2",
                    Note = "Oklahoma #2",
                    CategoryId = Guid.Parse("be4cc0d7-029c-45b6-a121-726a53ccd21a"),
                    CreatedAt = DateTime.Now
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #3",
                    Note = "Oklahoma #3",
                    CategoryId = Guid.Parse("0fdc6594-102f-4f05-872b-6746b65bdee9"),
                    CreatedAt = DateTime.Now
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #3.1",
                    Note = "Oklahoma #3-1",
                    CategoryId = Guid.Parse("0fdc6594-102f-4f05-872b-6746b65bdee9"),
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
