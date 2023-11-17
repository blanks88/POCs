namespace ContextGenerator.Extensions;

public static class StringExtensions
{
    public static string ForceEndsWith(
        this string source,
        string suffix)
    {
        if (source.EndsWith(suffix))
        {
            return source;
        }

        return source + suffix;
    }
}
