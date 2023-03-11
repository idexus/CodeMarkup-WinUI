//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CodeMarkup.WinUI.Generator.Extensions
{
    [Generator]
    public class Builder : ISourceGenerator
    {        
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            // Helpers.WaitForDebugger(context.CancellationToken);

            var winUISymbolsClass = context.Compilation.GetSymbolsWithName(s => true, filter: SymbolFilter.Type)
                .Where(e => e.ToDisplayString().Equals($"{Shared.CoreLibPrefix}.Internal.WinUISymbols"))
                .ToList()
                .FirstOrDefault() as INamedTypeSymbol;

            if (winUISymbolsClass != null)
            {
                var winUISymbols = winUISymbolsClass
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Field)
                    .Select(e => (e as IFieldSymbol).Type as INamedTypeSymbol)
                    .ToList();

                var baseSymbols = new List<INamedTypeSymbol>();
                foreach (var symbol in winUISymbols)
                    Helpers.LoopDownToObject(symbol.BaseType, type =>
                    {
                        if (!baseSymbols.Contains(type) && !winUISymbols.Contains(type)) baseSymbols.Add(type);
                        return false;
                    });

                var allSymbols = winUISymbols.ToList();
                allSymbols.AddRange(baseSymbols);

                foreach (var symbol in allSymbols)
                {
                    new ExtensionGenerator(context, symbol).Build();
                }
            }

            // [SharpObject] symbols

            var sharpSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.CodeMarkupAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in sharpSymbols)
            {
                new ExtensionGenerator(context, symbol).Build();
            }


            // [AttachedInterfaces] symbols

            var staticWithAttachedSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.AttachedInterfacesAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in staticWithAttachedSymbols)
            {
                new ExtensionGenerator(context, symbol).Build();
            }
        }
    }
}