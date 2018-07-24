using System;
using System.Linq;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class SymbolTableTests : GenerationTestBase
	{
		[Test]
		public void TestAliasMapping ()
		{
			var repo = ParseGirFile (GLib, out var mainRepository);
			var opts = GetOptions (repo, mainRepository);

			Assert.AreEqual (opts.SymbolTable ["guint8"], opts.SymbolTable ["DateDay"]);
		}

		[TestCase (Gdk3, 0)]
		[TestCase (GLib, 0)]
		[TestCase (Gtk3, 0)]
		[TestCase (Pango, 0)]
		[TestCase (GIMarshallingTests, 0)]
		public void TestSymbolTableErrorsTracker (string girFile, int errorCount)
		{
			var repo = ParseGirFile (girFile, out var mainRepository);
			var opts = GetOptions (repo, mainRepository);

			var stats = opts.Statistics.Errors.ToArray ();

			// FUTURE: This should be 0.
			Assert.AreEqual (errorCount, stats.Length);
			foreach (var error in stats) {
				Console.WriteLine (error.Message);
			}
		}

		[TestCase (Library.Gtk2)]
		[TestCase (Library.Gtk3)]
		public void NoAliasTypeAfterProcessing (Library library)
		{
			foreach (var tpl in ParseAllGirFiles (library)) {
				var repo = tpl.Item2;
				var mainRepository = tpl.Item1;

				var opts = GetOptions (repo, mainRepository);

				Assert.AreEqual (0, opts.SymbolTable.OfType<Alias> ().Count ());
			}
		}

		[Test]
		public void CanResolveIncludedFiles ()
		{
			var repo = ParseGirFile (Gtk3, out var mainRepository);
			var opts = GetOptions (repo, mainRepository);

			Assert.NotNull (opts.SymbolTable["GdkPixbuf.PixbufError"]);
		}
	}
}
