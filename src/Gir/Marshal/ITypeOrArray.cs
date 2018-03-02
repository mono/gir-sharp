using System;
namespace Gir
{
	public interface ITypeOrArray
	{
		Type Type { get; }
		Array Array { get; }
	}

	public static class ITypeOrArrayExtensions
	{
		public static ISymbol Resolve (this ITypeOrArray toResolve, GenerationOptions opts)
		{
			return toResolve.Array?.GetSymbol(opts) ?? toResolve.Type.GetSymbol(opts);
		}
	}
}
