using System.Text;
using ContextGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace ContextGenerator;

[Generator]
#pragma warning disable RS1036
public class ContextDbSetsGenerator : ISourceGenerator
#pragma warning restore RS1036
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        try
        {
            var members = context.Compilation
                .GetSymbolsByAttribute<EntityDbSetAttribute>()
                .ToList();

            var sourceCode = GetSourceCodeFor(members);

            context.AddSource(
                "Context.g.cs",
                SourceText.From(sourceCode, Encoding.UTF8));

            Console.WriteLine(sourceCode);
        }
        catch (Exception e)
        {
            throw new Exception(e.StackTrace);
        }
    }

    private string GetSourceCodeFor(IEnumerable<INamedTypeSymbol> entities,
        string? template = null)
    {
        // If template isn't provided, use default one from embedded resources.
        template ??= GetEmbededResource("ContextGenerator.Templates.Context.txt");

        // entities code
        var code = string.Join("\n",
            entities
                .Select(e =>
                    $"    public virtual DbSet<{e.Name}> {e.Name}s {{ get; set; }} = null!;"
                )
        );

        // Can't use scriban at the moment, make it manually for now.
        return template.Replace("{{DbSets}}", code);
    }

    private string GetEmbededResource(string path)
    {
        using var stream = GetType().Assembly.GetManifestResourceStream(path);

        if (stream == null)
        {
            return string.Empty;
        }

        using var streamReader = new StreamReader(stream);

        return streamReader.ReadToEnd();
    }
}
