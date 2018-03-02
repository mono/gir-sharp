
namespace Gir
{
	public partial class Interface : IGeneratable, IDocumented
	{
		// TODO, We should probably add 'I' to 'Name' unless in compat mode
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				writer.WriteLine ("namespace " + opts.Namespace.Name);
				writer.WriteLine ("{");
				using (writer.Indent ()) {
					this.GenerateDocumentation (writer);
					writer.WriteLine ($"public interface {Name}");
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
