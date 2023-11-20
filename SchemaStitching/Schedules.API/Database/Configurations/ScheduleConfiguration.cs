using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedules.API.Models;
using Sidearm.V3.EntityFramework.Extensions;

namespace Schedules.API.Database.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder
            .Property(e => e.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(e => e.Note)
            .HasMaxLength(8000);

        // Schema stitching
        builder
            .Property(e => e.CategoryId)
            .IsRequired();

        // Metadata
        builder.SetHasId();
        builder.SetAsTrackable();
        builder.SetAsTenantBase();
        builder.SetAsSoftDeletable();
    }
    
}
