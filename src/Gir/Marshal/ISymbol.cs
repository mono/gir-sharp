
namespace Gir
{
	public interface ISymbol
	{
		string CSharpType { get; }
		string Name { get; }
		string DefaultValue { get; }
	}
}
