using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public partial class Class : IGeneratable, IDocumented
	{
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				writer.WriteLine ("namespace " + opts.Namespace.Name);
				writer.WriteLine ("{");
				using (writer.Indent ()) {
					this.GenerateDocumentation (writer);

					var inheritanceList = new List<string> ();
					if (!string.IsNullOrEmpty (Parent))
						inheritanceList.Add (Parent);
					inheritanceList.AddRange (Implements.Select (x => opts.GenerateInterfacesWithIPrefix ? "I" + x.Name : x.Name));

					var inheritanceString = string.Join (", ", inheritanceList.ToArray ());
					writer.WriteLine ($"public class {Name} : {inheritanceString}");
					writer.WriteLine ("{");

					using (writer.Indent ()) {
						this.GenerateMembers (writer);
					}
					writer.WriteLine ("}");
				}
				writer.WriteLine ("}");
			}

		}
	}
}
