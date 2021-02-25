using System.Collections.Generic;
using System.Linq;

namespace Gir
{
	public partial class Class : IGeneratable, IDocumented
	{
		public void Generate (GenerationOptions opts)
		{
			using var writer = this.GetWriter (opts);
			this.GenerateDocumentation (writer);

			var inheritanceList = new List<string> ();
			if (!string.IsNullOrEmpty (Parent))
				inheritanceList.Add (Parent);
			inheritanceList.AddRange (Implements.Select (x => opts.GenerateInterfacesWithIPrefix ? "I" + x.Name : x.Name));

			var inheritanceString = string.Join (", ", inheritanceList.ToArray ());
			if (!string.IsNullOrEmpty (inheritanceString)) {
				writer.WriteLine ($"public class {Name} : {inheritanceString}");
			} else {
				writer.WriteLine ($"public class {Name}");
			}
			writer.WriteLine ("{");

			using (writer.Indent ()) {
				this.GenerateMembers (writer);
			}
			writer.WriteLine ("}");
		}
	}
}
