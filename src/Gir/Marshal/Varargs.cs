using System;
namespace Gir
{
	public partial class Varargs : ISymbol
	{
		public string CSharpType => "...";

		public string Name => "va_list";

		public string DefaultValue => "";
	}
}
