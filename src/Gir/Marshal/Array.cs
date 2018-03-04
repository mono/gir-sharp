using System;
namespace Gir
{
	public partial class Array
	{
		public ISymbol GetSymbol (GenerationOptions opts)
		{
			if (Name != null) {
				return opts.SymbolTable [Name];
			}
			else {
				return opts.SymbolTable [Type.Name];
			}
		}
	}
}
