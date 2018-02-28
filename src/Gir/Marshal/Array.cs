using System;

namespace Gir
{
	public partial class Array : ISymbol
	{
		public string DefaultValue => throw new NotImplementedException();

		string ISymbol.CType => throw new NotImplementedException();
	}
}
