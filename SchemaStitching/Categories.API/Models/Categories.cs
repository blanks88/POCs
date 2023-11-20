using Sidearm.V3.Core.Models;

namespace Categories.API.Models;

public class Categories
    : IHasIdEntity,
        ITenantBaseEntity,
        ITrackableEntity,
        IHiddableEntity,
        ISoftDeletableEntity
{
    public Guid Id { get; set; }
    public string Tenant { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Abbrev { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string ShortDisplay { get; set; } = null!;

    // Metadata
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsHidden { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
