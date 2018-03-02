using System;
namespace Gir
{
	public partial class Callback : ISymbol
	{
		public string CSharpType => Name;

		public string DefaultValue => "null";
	}
}
