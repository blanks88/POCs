using Microsoft.EntityFrameworkCore;

namespace Schedules.API.Database;

public class ContextScopedFactory : IDbContextFactory<Context>
{
    private readonly IDbContextFactory<Context> _pooledFactory;

    public ContextScopedFactory(IDbContextFactory<Context> pooledFactory)
    {
        _pooledFactory = pooledFactory;
    }

    public Context CreateDbContext() => _pooledFactory.CreateDbContext();
}
