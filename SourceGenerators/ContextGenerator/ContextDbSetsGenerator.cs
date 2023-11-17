using System.Text;
using ContextGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace ContextGenerator;

[Generator]
public class ContextDbSetsGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // context.Compilation.GetAllSymbols();
        // finding Core reference assembly Symbols
        IAssemblySymbol assemblySymbol =
            context.Compilation.SourceModule.ReferencedAssemblySymbols
                .First(q => q.Name == "MultiTenancy.Core");

        // use assembly symbol to get namespace and type symbols
        // all members in namespace Core.Entities
        var members = assemblySymbol.GlobalNamespace.GetNamespaceMembers()
            .First(q => q.Name == "MultiTenancy")
            .GetNamespaceMembers().First(q => q.Name == "Core")
            .GetNamespaceMembers().First(q => q.Name == "Models")
            .GetTypeMembers()
            .Where(tm =>
                tm.GetAttributes().Any(attr =>
                    attr.AttributeClass?.Name == nameof(DatabaseEntityAttribute)))
            .ToList();
        
        var sourceCode = GetSourceCodeFor(members);

        context.AddSource(
            "Context.g.cs",
            SourceText.From(sourceCode, Encoding.UTF8));
        Console.WriteLine(sourceCode);
    }

    private string GetSourceCodeFor(IEnumerable<INamedTypeSymbol> entities, string? template = null)
    {
        // If template isn't provieded, use default one from embeded resources.
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
