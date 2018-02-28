using System;
namespace Gir
{
	public partial class Enumeration : ISymbol
	{
		// FIXME: Probably default to the first value
		public string DefaultValue => "default(" + Name + ")";
		public string CSharpType => Name;
	}
}
