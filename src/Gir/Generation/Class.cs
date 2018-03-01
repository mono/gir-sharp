using System;

namespace Gir
{
	public partial class Class : IGeneratable, IDocumented
	{
		public void Generate(GenerationOptions opts)
		{
			using (var writer = this.GetWriter(opts)) {
				writer.WriteLine("namespace " + opts.Namespace.Name);
				writer.WriteLine("{");
				using (writer.Indent()) {
					this.GenerateDocumentation(writer);
					writer.WriteLine($"public class {Name} : {String.Join(", ", Implements)}");
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
