using System;
namespace Gir
{
	public partial class Array
	{
		public ISymbol GetSymbol (GenerationOptions opts)
		{
			if (Name != null)
				return opts.SymbolTable [Name];

			// TODO: Here, we need to return a custom ISymbol implementation for a plain array in case name is not null.
			return opts.SymbolTable [Type.Name];
		}
	}
}
