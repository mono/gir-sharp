using System;
using System.IO;

namespace Gir
{
	public sealed class GenerationOptions
	{
		public string DirectoryPath { get; }
		public Namespace Namespace { get; }
		public Stream RedirectStream { get; set; }

		bool compat;
		public bool GenerateDocumentation { get { return !compat; } }

		public GenerationOptions(string dir, Namespace ns, bool compat = false)
		{
			DirectoryPath = dir;
			Namespace = ns;
			this.compat = compat;
		}
	}
}
