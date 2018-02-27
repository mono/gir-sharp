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
			var repo = ParseGirFile(GLib, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			Assert.AreEqual(opts.SymbolTable["guint8"], opts.SymbolTable["GDateDay"]);
		}

		[TestCase(Gdk3, 0)]
		[TestCase(GLib, 1)]
		[TestCase(Gtk3, 2)]
		[TestCase(Pango, 1)]
		public void TestSymbolTableErrorsTracker(string girFile, int errorCount)
		{
			var repo = ParseGirFile(girFile, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			var stats = opts.Statistics.Errors.ToArray ();

			// FUTURE: This should be 0.
			Assert.AreEqual(errorCount, stats.Length);
			foreach (var error in stats) {
				Console.WriteLine(error.Message);
			}
		}

		/*[Test]
		public void NoAliasTypeAfterProcessing ()
		{
			foreach (var repo in ParseAllGirFiles ()) {
				var opts = GetOptions(repo, mainRepository);

				Assert.AreEqual(0, opts.SymbolTable.OfType<Alias>().Count());
			}
		}*/

		[Test]
		public void VoidPointerWorks ()
		{
			var repo = ParseGirFile(GLib, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			Assert.AreEqual("gpointer", opts.SymbolTable["void*"].CType);
		}
	}
}
