using System;
namespace Gir
{
	public class Primitive : ISymbol
	{
		public string CType { get; }
		public string Name { get; }
		public string DefaultValue { get; }

		public Primitive(string ctype, string name, string defaultValue)
		{
			CType = ctype;
			Name = name;
			DefaultValue = defaultValue;
		}
	}
}
