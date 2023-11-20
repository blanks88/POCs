using Sidearm.V3.Core.Models;

namespace Schedules.API.Models;

public class Schedule : IHasIdEntity, ITenantBaseEntity, ITrackableEntity, ISoftDeletableEntity
{
    public Guid Id { get; set; }
    public string Tenant { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Note { get; set; } = null!;

    // Schema stitching
    public Guid CategoryId { get; set; }

    // Metadata
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
