using Schedules.API.Database;
using Schedules.API.Models;

namespace Schedules.API.Queries;

public class Query
{
    public IQueryable<Schedule> GetSchedules([Service] Context db)
        => db.Schedules;
}
