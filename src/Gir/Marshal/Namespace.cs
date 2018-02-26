using System;
using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<ISymbol> GetSymbols()
		{
			foreach (var en in Enumerations)
				yield return en;

			foreach (var alias in Aliases)
				yield return alias;
		}
	}
}
