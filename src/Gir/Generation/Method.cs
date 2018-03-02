using System;

namespace Gir
{
	public partial class Method : ICallable
	{
		public string GetModifiers (IGeneratable parent) => "public";

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			if (Deprecated)
				writer.WriteLine ($"[Obsolete (\"(Version: {DeprecatedVersion}) {DocDeprecated.Text}\")]");

			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		public bool IsInstanceCallable => true;
	}
}
