using Microsoft.EntityFrameworkCore;
using Schedules.API.Database;
using Schedules.API.Models;
using Schedules.API.Models.Dependencies;

namespace Schedules.API.Queries;

public class Query
{
    public IQueryable<Schedule> GetSchedules([Service] Context db)
        => db.Schedules;

    public async Task<Category> GetCategory(
        [Service] Context db, Guid id)
        => new(
            Id: id,
            Schedules: await db.Schedules.Where(s =>
                    s.CategoryId == id)
                .ToListAsync()
        );
}
