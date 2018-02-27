using System;
namespace Gir
{
	public partial class Type
	{
		public ISymbol GetSymbol (GenerationOptions opts)
		{
			return opts.SymbolTable[CType];
		}
	}
}
