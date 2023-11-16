using MultiTenancy.Core.Models;
using MultiTenancy.Database;

namespace MultiTenancyAPI.Queries;

public class SchedulesQuery
{
    public IQueryable<Schedule> GetSchedule([Service] Context db)
        => db.Schedules;
}
