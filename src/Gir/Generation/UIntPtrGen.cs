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

		public void WriteAccessors (StreamWriter sw, string indent, string var)
		{
			sw.WriteLine(indent + "get {");
			sw.WriteLine(indent + $"\treturn {FromNative(var)};");
			sw.WriteLine(indent + "}");
			sw.WriteLine(indent + "set {");
			sw.WriteLine(indent + $"\t{var} = {CallByName("value")};");
			sw.WriteLine(indent + "}");
		}
	}
}
