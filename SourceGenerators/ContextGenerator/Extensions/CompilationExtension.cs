using Microsoft.CodeAnalysis;

namespace ContextGenerator.Extensions;

public static class CompilationExtension
{
    public static IEnumerable<INamedTypeSymbol> GetSymbolsByAttribute<TAttribute>(
        this Compilation compilation) where TAttribute : Attribute
        => compilation.GetAllSymbols()
            .Where(tm => tm != null
                         && tm.GetAttributes()
                             .Any(attr
                                 => !string.IsNullOrEmpty(attr.AttributeClass?.Name)
                                    && typeof(TAttribute).ToString()
                                        .EndsWith(attr.AttributeClass!.Name)
                             )
            );

    private static IEnumerable<INamedTypeSymbol> GetAllSymbols(
        this Compilation compilation)
    {
        var visitor = new AllSymbolsVisitor();
        visitor.Visit(compilation.GlobalNamespace);
        return visitor.AllTypeSymbols;
    }

    private class AllSymbolsVisitor : SymbolVisitor
    {
        public List<INamedTypeSymbol> AllTypeSymbols { get; } = new();

        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            Parallel.ForEach(symbol.GetMembers(), s => s.Accept(this));
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            AllTypeSymbols.Add(symbol);
            foreach (var childSymbol in symbol.GetTypeMembers())
            {
                base.Visit(childSymbol);
            }
        }
    }
}
