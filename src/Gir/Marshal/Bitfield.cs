using System;
namespace Gir
{
	public partial class Bitfield : ISymbol
	{
		// FIXME: Probably default to the first value
		public string DefaultValue => "default(" + Name + ")";
	}
}
