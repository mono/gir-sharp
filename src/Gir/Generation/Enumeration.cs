using System;
using System.IO;

namespace Gir
{
	public partial class Enumeration : IGeneratable, IType
	{
		public void Generate(GenerationOptions opts)
		{
			using (var writer = this.GetWriter(opts)) {
				writer.WriteLine("namespace " + opts.Namespace.Name);
				writer.WriteLine("{");
				using (writer.Indent()) {
					writer.WriteDocumentation(Doc);
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

		void GenerateMembers (IndentWriter writer)
		{
			foreach (var member in Members) {
				writer.WriteDocumentation(member.Doc);
				writer.WriteLine(member.Name.ToCSharp () + " = " + member.Value + ",");
			}
		}
	}
}
