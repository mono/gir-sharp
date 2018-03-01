using System;

namespace Gir
{
	public partial class Interface : ISymbol
	{
		public string CSharpType => "I" + Name;

		public string DefaultValue => throw new NotImplementedException();
	}
}
