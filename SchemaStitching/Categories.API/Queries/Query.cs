using Categories.API.Database;

namespace Categories.API.Queries;

public class Query
{
    public IQueryable<Models.Categories> GetCategories([Service] Context db)
        => db.Categories;
}
