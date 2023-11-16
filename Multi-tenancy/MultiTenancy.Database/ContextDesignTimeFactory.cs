using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Primitives;
using MultiTenancy.App;
using MultiTenancy.App.Resolvers;

namespace MultiTenancy.Database;

/// <summary>
/// Class to help to update database from the command line
/// </summary>
public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
{
    private class TenantResolver(string? tenantName) : ITenantResolver
    {
        public string? GetTenantName() => tenantName;
    }

    public Context CreateDbContext(string[] args)
    {
        string connectionString = GetConnectionString(args);
        ITenantResolver tenant = new TenantResolver(GetTenantName(args));

        DbContextOptionsBuilder<Context> optionsBuilder = new();
        optionsBuilder.UseNpgsql(connectionString);

        var result = new Context(optionsBuilder.Options);
        result.TenantId = tenant.GetTenantName()!;
        return result;
    }

    private static string GetConnectionString(IEnumerable<string> args)
        => GetVarValue(args, "connection-string", required: true);

    private static string GetTenantName(IEnumerable<string> args)
        => GetVarValue(args, "tenant", required: true);

    private static string GetMigrationsTable(IEnumerable<string> args)
        => GetVarValue(args, "migrations-table", "__EFMigrationsHistory");

    private static string GetVarValue(IEnumerable<string> args, string var,
        string fallback = "", bool required = false)
    {
        foreach (string arg in args)
        {
            if (!Regex.IsMatch(arg, $"{var}=")) continue;

            string result = arg[(1 + arg.IndexOf('='))..];
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{var}={result}");
            Console.ResetColor();
            if (!string.IsNullOrEmpty(result)) { return result; }
        }

        if (!required) return fallback;

        string upper = var.ToUpper();
        throw new InvalidOperationException(
            $"{upper} is missing, please add (e.g.: dotnet ef database update -- --{var}=\"MY_{upper}\")"
        );
    }
}
