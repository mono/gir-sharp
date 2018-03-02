using System;

namespace Gir
{
	public partial class Alias : ISymbol
	{
		public string CSharpType => throw new NotSupportedException ();
		public string DefaultValue => throw new NotSupportedException ();
	}
}
