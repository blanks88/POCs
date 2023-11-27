using Microsoft.EntityFrameworkCore;

namespace Schedules.API.Database;

public class ContextScopedFactory(IDbContextFactory<Context> pooledFactory)
    : IDbContextFactory<Context>
{
    public Context CreateDbContext() => pooledFactory.CreateDbContext();
}
