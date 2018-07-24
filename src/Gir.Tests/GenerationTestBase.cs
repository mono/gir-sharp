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
		protected const string Gtk2Directory = "Gtk2";
		protected const string Gtk3Directory = "Gtk3";

		protected const string Gtk2Gdk2 = "Gtk2.Gdk-2.0";
		protected const string Gtk2GLib = "Gtk2.GLib-2.0";
		protected const string Gtk2Atk1 = "Gtk2.Atk-1.0";
		protected const string Gtk2 = "Gtk2.Gtk-2.0";

		protected const string Gdk3 = "Gtk3.Gdk-3.0";
		protected const string GLib = "Gtk3.GLib-2.0";
		protected const string Gtk3 = "Gtk3.Gtk-3.0";
		protected const string GObject = "Gtk3.GObject-2.0";
		protected const string Pango = "Gtk3.Pango-1.0";
		protected const string Gio2 = "Gtk3.Gio-2.0";
		protected const string Atk1 = "Gtk3.Atk-1.0";

		protected const string GIMarshallingTests = "GIMarshallingTests-1.0";

		public static string IncludeDirectory = Gtk3Directory;
		static IEnumerable<Stream> GetResourceStreams (string name = null)
		{
			var assembly = Assembly.GetExecutingAssembly ();

			var names = assembly.GetManifestResourceNames ();
			foreach (var resName in names) {
				if (string.IsNullOrEmpty (resName) || resName.EndsWith (name + ".gir", StringComparison.OrdinalIgnoreCase))
					yield return assembly.GetManifestResourceStream (resName);
			}
		}

		static string GetIncludeDirectory ()
		{
			return Path.Combine (Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location), "TestFiles", IncludeDirectory);
		}

		protected static IEnumerable<Tuple<Repository, IEnumerable<Repository>>> ParseAllGirFiles ()
		{
			foreach (var stream in GetResourceStreams ()) {
				var repos = ParseGirStream (stream, out Repository mainRepository);

				yield return new Tuple<Repository, IEnumerable<Repository>> (mainRepository, repos);
			}
		}

		protected static Stream GetGirFile (string name)
		{
			if (name.Contains ("Gtk2"))
				IncludeDirectory = Gtk2Directory;
			if (name.Contains ("Gtk3"))
				IncludeDirectory = Gtk3Directory;

			return GetResourceStreams (name).Single ();
		}

		protected static IEnumerable<Repository> ParseGirFile (string name, out Repository mainRepository)
		{
			return ParseGirStream (GetGirFile (name), out mainRepository);
		}

		protected static IEnumerable<Repository> ParseGirStream (Stream gir, out Repository mainRepository)
		{
			return Parser.Parse (gir, GetIncludeDirectory (), out mainRepository);
		}


		protected static string GetGenerationResult (GenerationOptions opts)
		{
			var ms = (MemoryStream)opts.RedirectStream;
			return Encoding.UTF8.GetString (ms.ToArray ());
		}

		protected static GenerationOptions GetOptions (IEnumerable<Repository> repositories, Repository mainRepository, bool compat = false, bool generateMember = false)
		{
			return new GenerationOptions ("", repositories, mainRepository, new GenerationOptions.ToggleOptions {
				Compat = compat,
				RedirectStream = new MemoryStream (),
				WriteHeader = !generateMember,
				// Note, all of the tests assume "\n" and not "\r\n"
				NewLine = "\n"
			});
		}

		protected static void GenerateType (Repository repo, GenerationOptions opts, string typeName)
		{
			repo.GetGeneratables ().First (x => x.Name == typeName).Generate (opts);
		}

		protected static void GenerateMember (Repository repo, GenerationOptions opts, string typeName, string memberName)
		{
			var type = repo.GetGeneratables ().First (x => x.Name == typeName);

			using (var writer = type.GetWriter (opts)) {
				type.GenerateMembers (writer, x => x.Name == memberName);
			}
		}

		protected static string GenerateType (string girFile, string typeName, bool compat = false)
		{
			var repositories = ParseGirFile (girFile, out var mainRepository);
			var opts = GetOptions (repositories, mainRepository, compat);

			GenerateType (mainRepository, opts, typeName);

			return GetGenerationResult (opts);
		}

		protected static string GenerateMember (string girFile, string typeName, string memberName, bool compat = false)
		{
			var repositories = ParseGirFile (girFile, out var mainRepository);
			var opts = GetOptions (repositories, mainRepository, compat, generateMember: true);

			GenerateMember (mainRepository, opts, typeName, memberName);

			return GetGenerationResult (opts);
		}
	}
}
