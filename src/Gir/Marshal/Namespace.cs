using System;
using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<ISymbol> GetSymbols()
		{
			return Utils.GetAllCollectionMembers<ISymbol>(this);
		}
	}
}
