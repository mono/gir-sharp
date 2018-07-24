using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gir
{
	public sealed class GenerationOptions
	{
		public SymbolTable SymbolTable { get; }
		public Statistics Statistics { get; } = new Statistics ();
		public ToggleOptions Options { get; }

		#region Generation information
		public string DirectoryPath { get; }
		public string Namespace => Repository.Namespace.Name;
		public IEnumerable<string> UsingNamespaces => AllRepositories.Select (x => x.Namespace.Name);
		public Stream RedirectStream => Options.RedirectStream;

		public string LibraryName { get; }

		public IEnumerable<IGeneratable> AllGeneratables => allGeneratables;
		#endregion

		#region Generation toggles
		public bool GenerateDocumentation => !Options.Compat;
		public bool GenerateInterfacesWithIPrefix => !Options.Compat;
		public bool WriteHeader => Options.WriteHeader;

		// Try to find better logic for detecting this.
		public bool NativeWin64 => Options.Win64Longs;

		public string NewLine => Options.NewLine;
		#endregion

		#region Symbols

		#endregion

		IEnumerable<Repository> AllRepositories { get; }
		Repository Repository { get; }
		List<IGeneratable> allGeneratables = new List<IGeneratable> ();

		public GenerationOptions (string dir, IEnumerable<Repository> allRepos, Repository repo, ToggleOptions options = null)
		{
			// Set options to default if none
			Options = options ?? new ToggleOptions ();

			DirectoryPath = dir;
			AllRepositories = allRepos;
			Repository = repo;
			allGeneratables.AddRange (Repository.GetGeneratables ());

			// This may contain multiple libraries, so get the first one. Also, hack a string.Empty for xlib.
			LibraryName = repo.Namespace.SharedLibrary?.Split (',') [0] ?? "";

			SymbolTable = new SymbolTable(Statistics, Options.Win64Longs);

			// Register the main repository once without namespace names and once with them.
			SymbolTable.AddTypes (repo.GetSymbols());
			foreach (var repository in allRepos) {
				SymbolTable.AddTypes (repository.GetSymbols(), repository);
			}
			SymbolTable.ProcessAliases();
		}

		public class ToggleOptions
		{
			public bool Compat;
			public Stream RedirectStream;
			public bool Win64Longs;
			public bool WriteHeader = true;
			public string NewLine = Environment.NewLine;
		}
	}
}
