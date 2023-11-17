using Microsoft.CodeAnalysis;

namespace ContextGenerator.Shared;

public class GetAllSymbolsVisitor: SymbolVisitor
{
    public override void VisitNamespace(INamespaceSymbol symbol)
    {
        Parallel.ForEach(symbol.GetMembers(), s => s.Accept(this));
    }

    public override void VisitNamedType(INamedTypeSymbol symbol)
    {
        // Do what you need to here (add to collection, etc.)
    }
}
