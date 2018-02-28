using System;
namespace Gir
{
	public interface ISymbol
	{
		string CSharpType { get; }
		string CType { get; }
		string DefaultValue { get; }
	}
}
