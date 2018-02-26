using System.IO;

namespace Gir
{
	public class UIntPtrGen : Primitive, IAccessor
	{
		public UIntPtrGen (string ctype) : base( ctype, "ulong", "0") { }

		public override string MarshalType => "UIntPtr";

		public override string CallByName (string var)
		{
			return $"new UIntPtr ({var})";
		}

		public override string FromNative (string var)
		{
			return $"(ulong) {var}";
		}

		public void WriteAccessors (IndentWriter indentWriter, string fieldName)
		{
			indentWriter.WriteLine("get {");
			indentWriter.WriteLine($"\treturn {FromNative(fieldName)};");
			indentWriter.WriteLine("}");
			indentWriter.WriteLine("set {");
			indentWriter.WriteLine($"\t{fieldName} = {CallByName("value")};");
			indentWriter.WriteLine("}");
		}
	}
}
