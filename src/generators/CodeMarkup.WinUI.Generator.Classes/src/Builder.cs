//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CodeMarkup.WinUI.Generator.SharpObjects
{
    [Generator]
    public class Builder : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            //Helpers.WaitForDebugger(context.CancellationToken);

            var codeMarkupSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.CodeMarkupAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);


            foreach (var symbol in codeMarkupSymbols)
            {
                new ClassGenerator(context, symbol, true).Build();
            }

            var winUISymbolsClass = context.Compilation.GetSymbolsWithName(s => true, filter: SymbolFilter.Type)
                .Where(e => e.ToDisplayString().Equals($"CodeMarkup.Internal.WinUISymbols"))
                .ToList()
                .FirstOrDefault() as INamedTypeSymbol;

            if (winUISymbolsClass != null)
            {
                var winUISymbols = winUISymbolsClass
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Field)
                    .Select(e => (e as IFieldSymbol).Type as INamedTypeSymbol)
                    .Where(e => !e.IsSealed)
                    .ToList();

                var codeMarkupSymbolsBases = codeMarkupSymbols.Select(e => e.BaseType as INamedTypeSymbol).ToList();

                foreach (var symbol in winUISymbols)
                {
                    if (!codeMarkupSymbolsBases.Contains(symbol))
                        new ClassGenerator(context, symbol, false).Build();
                }
            }
        }
    }
}