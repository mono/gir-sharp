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

		static protected IEnumerable<Stream> GetAllGIRFiles()
		{
			return GetResourceStreams();
		}

		static protected Stream GetGIRFile (string name)
		{
			return GetResourceStreams(name).Single();
		}

		static protected Repository ParseGirFile (string name)
		{
			var gir = GetGIRFile(name);
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			return (Repository)serializer.Deserialize(gir);
		}


		protected static string GetGenerationResult(GenerationOptions opts)
		{
			var ms = (MemoryStream)opts.RedirectStream;
			return Encoding.UTF8.GetString(ms.ToArray());
		}

		protected static GenerationOptions GetOptions(Repository repo, bool compat = false)
		{
			var opts = new GenerationOptions("", repo.Namespace, compat, new MemoryStream ());
			opts.SymbolTable.AddTypes(repo.GetSymbols());
			opts.SymbolTable.ProcessAliases();
			return opts;
		}

		protected static void Generate (Repository repo, GenerationOptions opts, string name)
		{
			repo.GetGeneratables().First(x => x.Name == name).Generate(opts);
		}

		protected static string GenerateType (string girFile, string name, bool compat = false)
		{
			var repo = ParseGirFile(girFile);
			var opts = GetOptions(repo, compat);

			Generate(repo, opts, name);

			return GetGenerationResult(opts);
		}
	}
}
