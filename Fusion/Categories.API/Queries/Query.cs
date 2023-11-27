using Categories.API.Database;
using Categories.API.Models;

namespace Categories.API.Queries;

public class Query
{
    public IQueryable<Category> GetCategories([Service] Context db)
        => db.Categories;
    
    public ValueTask<Category?> GetCategory([Service] Context db, Guid id)
        => db.Categories.FindAsync(id);
}
