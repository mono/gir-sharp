using System;
namespace Gir
{
	public partial class Array
	{
		public ISymbol GetSymbol (GenerationOptions opts)
		{
			return opts.SymbolTable [CType];
		}
	}
}
