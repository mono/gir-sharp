using System;
namespace Gir
{
	public interface IHasType
	{
		Type Type { get; }
	}

	public static class IHasTypeExtensions
	{
		public static ISymbol GetSymbol(this IHasType type, GenerationOptions opts)
		{
			return opts.SymbolTable[type.Type.CType];
		}
	}
}
