using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidearm.V3.Core.Models;

namespace Sidearm.V3.EntityFramework.Extensions;

public static class TableConfigurationExtensions
{
    public static void SetHasId
        <TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IHasIdEntity
    {
        builder.HasKey(e => e.Id);
    }

    public static void SetAsTrackable
        <TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ITrackableEntity
    {
        builder.Property(e => e.CreatedAt)
            .IsRequired();
    }

    public static void SetAsHiddable
        <TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IHiddableEntity
    {
        builder.Property(e => e.IsHidden)
            .HasDefaultValue(false)
            .IsRequired();
    }

    public static void SetAsSoftDeletable
        <TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ISoftDeletableEntity
    {
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }

    public static void SetAsTenantBase
        <TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ITenantBaseEntity
    {
        builder.Property(e => e.Tenant)
            .HasMaxLength(50)
            .IsRequired();
    }
}
