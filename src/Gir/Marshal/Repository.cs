using System;
using System.Collections.Generic;

namespace Gir
{
	public partial class Repository
	{
		public IEnumerable<ISymbol> GetSymbols()
		{
			return Namespace.GetSymbols();
		}
	}
}
