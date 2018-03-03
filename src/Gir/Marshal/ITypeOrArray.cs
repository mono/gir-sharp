using System;
namespace Gir
{
	public interface ITypeOrArray : IType
	{
		Array Array { get; }
		Varargs Varargs { get; }
		Callback Callback { get; }
	}

	public static class ITypeOrArrayExtensions
	{
		public static ISymbol Resolve (this ITypeOrArray toResolve, GenerationOptions opts)
		{
			return toResolve.Array?.GetSymbol(opts) ?? toResolve.Type?.GetSymbol(opts) ?? (ISymbol)toResolve.Callback ?? toResolve.Varargs;
		}
	}
}
