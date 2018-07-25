
namespace Gir
{
	public partial class Record : IGeneratable, IDocumented
	{
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				this.GenerateDocumentation (writer);

				var access = "public";
				if (!string.IsNullOrEmpty (GLibIsGTypeStructFor))
					access = "internal";

				writer.WriteLine ("[StructLayout(LayoutKind.Sequential)]");
				writer.WriteLine ($"{access} struct {Name}");
				writer.WriteLine ("{");

				using (writer.Indent ()) {
					this.GenerateMembers (writer);
				}
				writer.WriteLine ("}");
			}
		}
	}
}
