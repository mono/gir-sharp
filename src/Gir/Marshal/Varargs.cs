using System;
namespace Gir
{
	public partial class Varargs : ISymbol
	{
		public string CSharpType => "...";

		public string CType => "va_list";

		public string DefaultValue => "";
	}
}
