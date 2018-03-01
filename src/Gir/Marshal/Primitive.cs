
namespace Gir
{
	public class Primitive : ISymbol
	{
		public string Name { get; }
		public string CSharpType { get; }
		public string DefaultValue { get; }

		public string ByValueMarshalType => CSharpType;

		public Primitive(string name, string csharpType, string defaultValue)
		{
			Name = name;
			CSharpType = csharpType;
			DefaultValue = defaultValue;
		}
	}

	public class StringMarshal : Primitive
	{
		public string MarshalType { get; }

		public StringMarshal (string ctype, string csharpType, string defaultValue, string marshalType) : base (ctype, csharpType, defaultValue)
		{
			MarshalType = marshalType;
		}
	}
}
