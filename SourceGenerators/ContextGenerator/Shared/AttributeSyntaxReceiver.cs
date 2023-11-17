using ContextGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ContextGenerator.Shared;

public class AttributeSyntaxReceiver<TAttribute> : ISyntaxReceiver
    where TAttribute : Attribute
{
    public IList<ClassDeclarationSyntax> Classes { get; }
        = new List<ClassDeclarationSyntax>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode
                is ClassDeclarationSyntax
                {
                    AttributeLists.Count: > 0
                } classDeclarationSyntax
            && classDeclarationSyntax.AttributeLists
                .Any(al => al.Attributes
                    .Any(a =>
                        a.Name.ToString().ForceEndsWith("Attribute")
                            .Equals(typeof(TAttribute).Name))))
        {
            Classes.Add(classDeclarationSyntax);
        }
    }
}
