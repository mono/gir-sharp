using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public abstract class GenerationTestBase
	{
		protected const string Gdk3 = "Gdk-3.0";
		protected const string GLib = "GLib-2.0";
		protected const string Gtk3 = "Gtk-3.0";
		protected const string Pango = "Pango-1.0";

		static IEnumerable<Stream> GetResourceStreams (string name = null)
		{
			var assembly = Assembly.GetExecutingAssembly();

			var names = assembly.GetManifestResourceNames();
			foreach (var resName in names) {
				if (string.IsNullOrEmpty (resName) || resName.EndsWith(name + ".gir", StringComparison.OrdinalIgnoreCase))
					yield return assembly.GetManifestResourceStream(resName);
			}
		}

		static protected IEnumerable<IEnumerable<Repository>> ParseAllGirFiles()
		{
			foreach (var stream in GetResourceStreams()) {
				yield return ParseGirStream (stream, out Repository mainRepository);
			}
		}

		static protected Stream GetGIRFile (string name)
		{
			return GetResourceStreams(name).Single();
		}

		static protected IEnumerable<Repository> ParseGirFile (string name, out Repository mainRepository)
		{
			return ParseGirStream(GetGIRFile(name), out mainRepository);
		}

		static protected IEnumerable<Repository> ParseGirStream (Stream gir, out Repository mainRepository)
		{
			return Parser.Parse(gir, Directory.GetCurrentDirectory(), out mainRepository);
		}


		protected static string GetGenerationResult(GenerationOptions opts)
		{
			var ms = (MemoryStream)opts.RedirectStream;
			return Encoding.UTF8.GetString(ms.ToArray());
		}

		protected static GenerationOptions GetOptions(IEnumerable<Repository> repositories, Repository mainRepository, bool compat = false)
		{
			var opts = new GenerationOptions("", mainRepository.Namespace, compat, new MemoryStream ());
			foreach (var repository in repositories) {
				opts.SymbolTable.AddTypes(repository.GetSymbols());
			}

			opts.SymbolTable.ProcessAliases();
			return opts;
		}

		protected static void Generate (Repository repo, GenerationOptions opts, string name)
		{
			repo.GetGeneratables().First(x => x.Name == name).Generate(opts);
		}

		protected static string GenerateType (string girFile, string name, bool compat = false)
		{
			var repositories = ParseGirFile(girFile, out var mainRepository);
			var opts = GetOptions(repositories, mainRepository, compat);
			
			Generate(mainRepository, opts, name);

			return GetGenerationResult(opts);
		}
	}
}
