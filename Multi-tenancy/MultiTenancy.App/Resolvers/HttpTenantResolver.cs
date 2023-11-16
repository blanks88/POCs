using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace MultiTenancy.App.Resolvers;

public class HttpTenantResolver(IHttpContextAccessor httpContextAccessor)
    : ITenantResolver
{
    private const string TenantParamName = "tenant";

    public string? GetTenantName() => GetTenantFromHeader() ?? GetTenantFromQuery();

    private StringValues? GetTenantFromHeader()
    {
        if (httpContextAccessor.HttpContext?.Request.Headers
                .TryGetValue(TenantParamName, out StringValues result)
            == true)
        {
            return result;
        }

        return null;
    }

    private StringValues? GetTenantFromQuery()
        => httpContextAccessor.HttpContext?.Request.Query[TenantParamName];
}

public static class Injector
{
    public static IServiceCollection AddHttpTenantResolver(
        this IServiceCollection services)
        => services.AddScoped<ITenantResolver, HttpTenantResolver>();
}
