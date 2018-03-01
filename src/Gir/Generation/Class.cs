using System;
using System.Linq;

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

					var inheritanceList = string.Join(", ", Implements.Select(x => x.Name).ToArray());
					writer.WriteLine($"public class {Name} : {inheritanceList}");
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
