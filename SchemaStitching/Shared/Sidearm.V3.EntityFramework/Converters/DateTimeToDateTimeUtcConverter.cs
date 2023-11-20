using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Sidearm.V3.EntityFramework.Converters;

public class DateTimeToDateTimeUtcConverter : ValueConverter<DateTime, DateTime>
{
    public DateTimeToDateTimeUtcConverter()
        : base(c => DateTime.SpecifyKind(c, DateTimeKind.Utc),
            c => c)
    {
    }
}
