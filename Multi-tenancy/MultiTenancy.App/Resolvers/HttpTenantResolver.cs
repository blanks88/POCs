using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace MultiTenancy.App.Resolvers;

public class HttpTenantResolver : ITenantResolver
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpTenantResolver(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private const string TenantParamName = "tenant";

    public string? GetTenantName() => GetTenantFromHeader() ?? GetTenantFromQuery();

    private StringValues? GetTenantFromHeader()
    {
        if (_httpContextAccessor.HttpContext?.Request.Headers
                .TryGetValue(TenantParamName, out StringValues result)
            == true)
        {
            return result;
        }

        return null;
    }

    private StringValues? GetTenantFromQuery()
        => _httpContextAccessor.HttpContext?.Request.Query[TenantParamName];
}

public static class Injector
{
    public static IServiceCollection AddHttpTenantResolver(
        this IServiceCollection services)
        => services.AddScoped<ITenantResolver, HttpTenantResolver>();
}
