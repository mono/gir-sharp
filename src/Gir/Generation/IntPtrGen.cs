using System.IO;

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

		public void WriteAccessors(StreamWriter sw, string indent, string var)
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
