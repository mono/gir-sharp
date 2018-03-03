
namespace Gir
{
	public partial class Record : IGeneratable, IDocumented
	{
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				this.GenerateDocumentation (writer);
				writer.WriteLine ("public struct " + Name);
				writer.WriteLine ("{");

				using (writer.Indent ()) {
					this.GenerateMembers (writer);
				}
				writer.WriteLine ("}");
			}
		}
	}
}
