
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Core.Models;

namespace MultiTenancy.Database;

public partial class Context
{
    public virtual DbSet<Schedule> Schedules { get; set; } = null!;
}
