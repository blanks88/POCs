namespace MultiTenancy.Core.Models.Abstractions;

public interface ITenantBaseEntity
{
    public string Tenant { get; set; }
}
