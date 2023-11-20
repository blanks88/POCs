namespace Sidearm.V3.Core.Models;

public interface ISoftDeletableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
