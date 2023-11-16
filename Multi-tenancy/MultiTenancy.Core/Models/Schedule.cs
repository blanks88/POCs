using MultiTenancy.Core.Models.Abstractions;

namespace MultiTenancy.Core.Models;

public class Schedule : IEntity, ITenantBaseEntity
{
    public Guid Id { get; set; }
    public string Tenant { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string Note { get; set; } = null!;
}
