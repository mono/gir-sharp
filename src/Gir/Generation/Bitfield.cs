using System;
using System.IO;

namespace Gir
{
	public partial class Bitfield : IGeneratable
	{
		public void Generate(GenerationOptions opts)
		{
			var path = Path.Combine(opts.DirectoryPath, Name + ".cs");
			using (var writer = IndentWriter.OpenWrite(path, opts)) {
				writer.WriteLine("namespace " + opts.Namespace.Name);
				writer.WriteLine("{");
				writer.Indent();
				writer.WriteDocumentation(Doc);
				writer.WriteLine("[Flags]");
				writer.WriteLine("public enum " + Name);
				writer.WriteLine("{");
				writer.Indent();

				GenerateMembers(writer);

				writer.Unindent();
				writer.WriteLine("}");
				writer.Unindent();
				writer.WriteLine("}");
			}
		}

		void GenerateMembers(IndentWriter writer)
		{
			foreach (var member in Members) {
				writer.WriteDocumentation (member.Doc);
				writer.WriteLine (Utils.UppercaseFirst (member.Name) + " = " + member.Value + ",");
			}
		}
	}
}
