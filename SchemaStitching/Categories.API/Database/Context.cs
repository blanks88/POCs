using Categories.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sidearm.V3.Core.Models;
using Sidearm.V3.EntityFramework.Converters;

namespace Categories.API.Database;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Models.Categories> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

        modelBuilder.Entity<Models.Categories>()
            .HasData(
                new Models.Categories
                {
                    Id = Guid.Parse("402ab577-379f-4e42-86ea-9ecf2e454dd5"),
                    Tenant = "Sidearmu",
                    Title = "The Sidearm Category",
                    Abbrev = "SC",
                    ShortName = "SCat",
                    ShortDisplay = "Sidearm Category",
                    CreatedAt = DateTime.Now,
                },
                new Models.Categories
                {
                    Id = Guid.Parse("be4cc0d7-029c-45b6-a121-726a53ccd21a"),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Category #1",
                    Abbrev = "OC1",
                    ShortName = "OklCategory#1",
                    ShortDisplay = "Oklahoma Category #1",
                    CreatedAt = DateTime.Now,
                },
                new Models.Categories
                {
                    Id = Guid.Parse("0fdc6594-102f-4f05-872b-6746b65bdee9"),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Category #2",
                    Abbrev = "OC2",
                    ShortName = "OklCategory#2",
                    ShortDisplay = "Oklahoma Category #2",
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
