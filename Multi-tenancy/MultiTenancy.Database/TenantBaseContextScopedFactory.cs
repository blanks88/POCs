using Microsoft.EntityFrameworkCore;
using MultiTenancy.App;

namespace MultiTenancy.Database;

/// <summary>
/// This class customizes DbContext initialization.
/// </summary>
/// <param name="pooledFactory"></param>
/// <param name="tenantResolver"></param>
public class TenantBaseContextScopedFactory(
        IDbContextFactory<Context> pooledFactory,
        ITenantResolver tenantResolver)
    : IDbContextFactory<Context>
{
    private readonly string _tenantId = tenantResolver.GetTenantName()
        ?? throw new Exception("Tenant header mut be present");

    public Context CreateDbContext()
    {
        var context = pooledFactory.CreateDbContext();
        context.TenantId = _tenantId;
        return context;
    }
}
