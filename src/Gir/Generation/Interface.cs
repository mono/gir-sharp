
namespace Gir
{
	public partial class Interface : IGeneratable, IDocumented
	{
		public void Generate (GenerationOptions opts)
		{
			using var writer = this.GetWriter (opts);
			this.GenerateDocumentation (writer);
			var interfaceName = (opts.GenerateInterfacesWithIPrefix) ? $"I{Name}" : Name;
			writer.WriteLine ($"public interface {interfaceName}");
			writer.WriteLine ("{");

			using (writer.Indent ()) {
				this.GenerateMembers (writer);
			}
			writer.WriteLine ("}");
		}
	}
}
