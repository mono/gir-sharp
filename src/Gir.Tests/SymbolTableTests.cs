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
			var repo = ParseGirFile(GLib);
			var opts = GetOptions(repo);

			Assert.AreEqual(opts.SymbolTable["guint8"], opts.SymbolTable["GDateDay"]);
		}

		[TestCase(Gdk3, 0)]
		[TestCase(GLib, 1)]
		[TestCase(Gtk3, 2)]
		[TestCase(Pango, 1)]
		public void TestSymbolTableErrorsTracker(string girFile, int errorCount)
		{
			var repo = ParseGirFile(girFile);
			var opts = GetOptions(repo);

			var stats = opts.Statistics.Errors.ToArray ();

			// FUTURE: This should be 0.
			Assert.AreEqual(errorCount, stats.Length);
			foreach (var error in stats) {
				Console.WriteLine(error.Message);
			}
		}
	}
}
