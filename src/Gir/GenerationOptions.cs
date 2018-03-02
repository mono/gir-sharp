using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gir
{
	public sealed class GenerationOptions
	{
		public SymbolTable SymbolTable { get; }
		public Statistics Statistics { get; } = new Statistics ();

		#region Generation information
		public string DirectoryPath { get; }
		public Namespace Namespace => Repository.Namespace;
		public Repository Repository { get; }
		public Stream RedirectStream { get; }

		public string LibraryName => Repository.Namespace.SharedLibrary;
		#endregion

		#region Generation toggles
		public bool Compat { get; }
		public bool GenerateDocumentation { get { return !Compat; } }

		// Try to find better logic for detecting this.
		public bool NativeWin64 { get; }
		#endregion

		#region Symbols

		#endregion

		public GenerationOptions (string dir, IEnumerable<Repository> allRepos, Repository repo, bool compat = false, Stream redirectStream = null, bool win64Longs = false)
		{
			DirectoryPath = dir;
			Repository = repo;
			Compat = compat;
			RedirectStream = redirectStream;

			SymbolTable = new SymbolTable (Statistics, win64Longs);
			SymbolTable.AddTypes (allRepos.SelectMany (x => x.GetSymbols ()));
			SymbolTable.ProcessAliases ();
		}
	}
}
