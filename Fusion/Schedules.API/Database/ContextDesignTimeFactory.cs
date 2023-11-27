using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Schedules.API.Database;

public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<Context> optionsBuilder = new();
        optionsBuilder.UseNpgsql(GetConnectionString(args));

        return new Context(optionsBuilder.Options);
    }

    private static string GetConnectionString(IEnumerable<string> args)
        => GetVarValue(args, "connection-string", required: true);

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
