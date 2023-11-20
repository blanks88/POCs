using Microsoft.EntityFrameworkCore;

namespace Categories.API.Database;

public class ContextScopedFactory(IDbContextFactory<Context> pooledFactory)
    : IDbContextFactory<Context>
{
    public Context CreateDbContext() 
        => pooledFactory.CreateDbContext();
}
