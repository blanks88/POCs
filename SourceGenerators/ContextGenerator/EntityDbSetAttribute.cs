namespace ContextGenerator;

/// <summary>
/// Attribute to identify entities to add to the result context
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class EntityDbSetAttribute : Attribute
{
}
