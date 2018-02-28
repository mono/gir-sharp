using System;
namespace Gir
{
	public partial class Record : ISymbol
	{
		public string CSharpType => Name;

		public string DefaultValue => "default(" + Name + ")";
	}
}
