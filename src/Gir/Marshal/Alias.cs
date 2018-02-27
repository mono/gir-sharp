using System;
namespace Gir
{
	public partial class Alias : ISymbol
	{
		public string DefaultValue => throw new NotSupportedException();
	}
}
