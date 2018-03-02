
namespace Gir
{
	public partial class Bitfield : IGeneratable, IDocumented, IEnumFormatter
	{
		public string FormatValue (string value)
		{
			int intValue = int.Parse (value);

			// Maybe pad with leading zeroes based on the value?
			return string.Format ("0x{0:X}", intValue);
		}

		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts)) {
				writer.WriteLine ("namespace " + opts.Namespace.Name);
				writer.WriteLine ("{");
				using (writer.Indent ()) {
					this.GenerateDocumentation (writer);
					writer.WriteLine ("[Flags]");
					writer.WriteLine ("public enum " + Name);
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
