
namespace Gir
{
	public interface IType
	{
		Type Type { get; }
	}

	public static class IHasTypeExtensions
	{
		public static ISymbol GetSymbol (this IType type, GenerationOptions opts)
		{
			return opts.SymbolTable [type.Type.Name];
		}
	}
}
