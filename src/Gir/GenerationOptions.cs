using System;
namespace Gir
{
	public class GenerationOptions
	{
		public string DirectoryPath { get; }
		public Namespace Namespace { get; }

		public GenerationOptions (string dir, Namespace ns)
		{
			DirectoryPath = dir;
			Namespace = ns;
		}
	}
}
