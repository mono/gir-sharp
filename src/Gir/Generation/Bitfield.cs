using System;
using System.IO;

namespace Gir
{
	public partial class Bitfield : IGeneratable
	{
		public void Generate(GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				writer.WriteLine("namespace " + opts.Namespace.Name);
				writer.WriteLine("{");
				using (writer.Indent()) {
					writer.WriteDocumentation(Doc);
					writer.WriteLine("[Flags]");
					writer.WriteLine("public enum " + Name);
					writer.WriteLine("{");

					using (writer.Indent()) {
						GenerateMembers(writer);
					}
					writer.WriteLine("}");
				}
				writer.WriteLine("}");
			}
		}

		void GenerateMembers(IndentWriter writer)
		{
			foreach (var member in Members) {
				writer.WriteDocumentation(member.Doc);
				writer.WriteLine(member.Name.ToCSharp() + " = " + HexFormat(member.Value) + ",");
			}
		}

		string HexFormat(string text)
		{
			int value = int.Parse(text);

			// Maybe pad with leading zeroes based on the value?
			return string.Format("0x{0:X}", value);
		}
	}
}
