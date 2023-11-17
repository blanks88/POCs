using Microsoft.EntityFrameworkCore;
using MultiTenancy.Core.Models;
using MultiTenancy.Core.Models.Abstractions;

namespace MultiTenancy.Database;

public partial class Context(DbContextOptions<Context> opts)
    : DbContext(opts), ITenantBaseContext
{
    public string TenantId { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Schedule>()
            .HasQueryFilter(
                b => EF.Property<string>(b, nameof(ITenantBaseEntity.Tenant)) == TenantId
            )
            .HasData(
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Sidearmu",
                    Title = "The Sidearm Schedule",
                    Note = "Sidearm u note"
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #1",
                    Note = "Oklahoma #1"
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Tenant = "Oklahoma",
                    Title = "The Oklahoma Schedule #2",
                    Note = "Oklahoma #2"
                }
            );
    }
}
