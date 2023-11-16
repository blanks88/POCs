namespace MultiTenancy.Database;

public interface ITenantBaseContext
{
    string TenantId { get; set; }
}
