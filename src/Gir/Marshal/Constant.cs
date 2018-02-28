using System;

namespace Gir
{
	public partial class Constant : ISymbol
	{
		public string DefaultValue => Value;
	}
}
