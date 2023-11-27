namespace Schedules.API.Models.Dependencies;

public record Category(Guid Id, IReadOnlyCollection<Schedule> Schedules);
