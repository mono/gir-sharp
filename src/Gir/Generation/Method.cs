using System;

namespace Gir
{
	public partial class Method : INativeCallable
	{
		public string GetModifiers (IGeneratable parent, GenerationOptions opts) => "public";

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			if (Deprecated)
				writer.WriteLine ($"[Obsolete (\"(Version: {DeprecatedVersion}) {DocDeprecated.Text}\")]");

			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		public bool IsInstanceCallable (IGeneratable parent, GenerationOptions opts) => true;
	}
}
