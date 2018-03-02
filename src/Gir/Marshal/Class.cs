
namespace Gir
{
	public partial class Class : ISymbol
	{
		public string CSharpType => Name;

		public string DefaultValue => throw new System.NotImplementedException ();
	}
}
