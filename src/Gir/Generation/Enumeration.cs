using System;
using System.IO;

namespace Gir
{
	public partial class Enumeration : IGeneratable
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
						this.GenerateMembers(opts, writer);
					}
					writer.WriteLine("}");
				}
				writer.WriteLine("}");
			}
		}
	}
}
