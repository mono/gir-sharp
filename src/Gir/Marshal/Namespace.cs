using System;
using System.Collections.Generic;

namespace Gir
{
	public partial class Namespace
	{
		public IEnumerable<ISymbol> GetSymbols() => Utils.GetAllCollectionMembers<ISymbol>(this);
	}
}
