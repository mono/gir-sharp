
namespace Gir
{
	public partial class Bitfield : IGeneratable, IDocumented, IEnumFormatter
	{
		public string FormatValue (string value)
		{
			var intValue = int.Parse (value);

			// Maybe pad with leading zeroes based on the value?
			return $"0x{intValue:X}";
		}

		public void Generate (GenerationOptions opts)
		{
			using var writer = this.GetWriter (opts);
			this.GenerateDocumentation (writer);
			writer.WriteLine ("[Flags]");
			writer.WriteLine ("public enum " + Name);
			writer.WriteLine ("{");

			using (writer.Indent ()) {
				this.GenerateMembers (writer);
			}
			writer.WriteLine ("}");
		}
	}
}
