using System;
namespace Gir
{
	public class Primitive : ISymbol
	{
		public string CType { get; private set; }
		public string Name { get; private set; }
		public string DefaultValue { get; private set; }

		public Primitive(string ctype, string name, string defaultValue)
		{
			CType = ctype;
			Name = name;
			DefaultValue = defaultValue;
		}
	}
}
