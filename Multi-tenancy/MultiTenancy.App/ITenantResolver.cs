namespace MultiTenancy.App;

public interface ITenantResolver
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string? GetTenantName();
}
