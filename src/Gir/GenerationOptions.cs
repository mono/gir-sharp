using System;
using System.IO;

namespace Gir
{
	public sealed class GenerationOptions
	{
		public SymbolTable SymbolTable { get; }
		public Statistics Statistics { get; } = new Statistics();

		#region Generation information
		public string DirectoryPath { get; }
		public Namespace Namespace { get; }
		public Stream RedirectStream { get; }
		#endregion

		#region Generation toggles
		readonly bool compat;
		public bool GenerateDocumentation { get { return !compat; } }

		// Try to find better logic for detecting this.
		public bool NativeWin64 { get; }
		#endregion

		#region Symbols

		#endregion

		public GenerationOptions(string dir, Namespace ns, bool compat = false, Stream redirectStream = null, bool win64Longs = false)
		{
			DirectoryPath = dir;
			Namespace = ns;
			this.compat = compat;

			SymbolTable = new SymbolTable(Statistics, win64Longs);
		}
	}
}
