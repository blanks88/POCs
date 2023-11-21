using Microsoft.EntityFrameworkCore;
using MultiTenancy.App;

namespace MultiTenancy.Database;

/// <summary>
/// This class customizes DbContext initialization.
/// </summary>
public class TenantBaseContextScopedFactory : IDbContextFactory<Context>
{
    private readonly string _tenantId;

    private readonly IDbContextFactory<Context> _pooledFactory;

    /// <summary>
    /// This class customizes DbContext initialization.
    /// </summary>
    /// <param name="pooledFactory"></param>
    /// <param name="tenantResolver"></param>
    public TenantBaseContextScopedFactory(
        IDbContextFactory<Context> pooledFactory,
        ITenantResolver tenantResolver)
    {
        _pooledFactory = pooledFactory;
        _tenantId = tenantResolver.GetTenantName()
                         ?? throw new Exception("Tenant header mut be present");
    }

    public Context CreateDbContext()
    {
        var context = _pooledFactory.CreateDbContext();
        context.TenantId = _tenantId;
        return context;
    }
}
