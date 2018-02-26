
namespace Gir
{
	public class IntPtrGen : Primitive, IAccessor
	{
		public IntPtrGen (string ctype) : base (ctype, "long", "0L") { }

		public override string MarshalType => "IntPtr";

		public override string CallByName(string var)
		{
			return $"new IntPtr ({var})";
		}

		public override string FromNative(string var)
		{
			return $"(long) {var}";
		}

		public void WriteAccessors(IndentWriter indentWriter, string fieldName)
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
