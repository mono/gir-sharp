using System;

namespace Gir
{
	public partial class Method : INativeCallable
	{
		public string GetModifiers (IGeneratable parent, GenerationOptions opts) => "public";

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			if (!string.IsNullOrEmpty (Deprecated)) {
				if (Deprecated == "0") {
				}
				else if (Deprecated == "1")
					writer.WriteLine ($"[Obsolete (\"(Version: {DeprecatedVersion}) {DocDeprecated.Text}\")]");
				else
					writer.WriteLine ($"[Obsolete (\"{Deprecated}\")]");
			}
			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		public bool IsInstanceCallable (IGeneratable parent, GenerationOptions opts) => true;
	}
}
