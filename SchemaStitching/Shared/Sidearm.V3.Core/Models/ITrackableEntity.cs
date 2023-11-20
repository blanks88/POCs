namespace Sidearm.V3.Core.Models;

public interface ITrackableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
