using System;
namespace Gir
{
	public partial class Enumeration
	{
		// FIXME: Probably default to the first value
		public string DefaultValue => "default(" + Name + ")";
	}
}
