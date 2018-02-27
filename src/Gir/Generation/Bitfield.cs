using System;
using System.IO;

namespace Gir
{
	public partial class Bitfield : IGeneratable, IDocumented
	{
		public void Generate(GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				writer.WriteLine("namespace " + opts.Namespace.Name);
				writer.WriteLine("{");
				using (writer.Indent()) {
					this.GenerateDocumentation(writer);
					writer.WriteLine("[Flags]");
					writer.WriteLine("public enum " + Name);
					writer.WriteLine("{");

					using (writer.Indent()) {
						this.GenerateMembers(writer);
					}
					writer.WriteLine("}");
				}
				writer.WriteLine("}");
			}
		}
	}
}
