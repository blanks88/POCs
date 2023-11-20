using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidearm.V3.EntityFramework.Extensions;

namespace Categories.API.Database.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Models.Categories>
{
    public void Configure(EntityTypeBuilder<Models.Categories> builder)
    {
        builder
            .Property(e => e.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(e => e.Abbrev)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(e => e.ShortName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(e => e.ShortDisplay)
            .HasMaxLength(50)
            .IsRequired();

        // Metadata
        builder.SetHasId();
        builder.SetAsTrackable();
        builder.SetAsTenantBase();
        builder.SetAsSoftDeletable();
        builder.SetAsHiddable();
    }

}
