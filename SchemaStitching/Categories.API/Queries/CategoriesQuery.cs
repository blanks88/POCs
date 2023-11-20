using Categories.API.Database;

namespace Categories.API.Queries;

public class CategoriesQuery
{
    public IQueryable<Models.Categories> GetCategories([Service] Context db)
        => db.Categories;
}
