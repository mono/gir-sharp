
namespace Gir
{
	public class Primitive : ISymbol
	{
		public string CType { get; }
		public string CSharpType { get; }
		public string DefaultValue { get; }

		public string ByValueMarshalType => CSharpType;

		public Primitive (string ctype, string csharpType, string defaultValue)
		{
			CType = ctype;
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
