using System;
namespace Gir
{
	public interface ISymbol
	{
		string Name { get; }
		string CType { get; }
		string DefaultValue { get; }
	}
}
