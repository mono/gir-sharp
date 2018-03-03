
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class Enumeration : GenerationTestBase
	{
		[Test]
		public void PangoAlignmentIsGenerated ()
		{
			var result = GenerateType (Pango, "Alignment");

			Assert.AreEqual (@"using System;

namespace Pango
{
	///<summary>
	/// A #PangoAlignment describes how to align the lines of a #PangoLayout within the
	/// available space. If the #PangoLayout is set to justify
	/// using pango_layout_set_justify(), this only has effect for partial lines.
	///</summary>
	public enum Alignment
	{
		///<summary>Put all available space on the right</summary>
		Left = 0,

		///<summary>Center the line within the available space</summary>
		Center = 1,

		///<summary>Put all available space on the left</summary>
		Right = 2,
	}
}
", result);
		}
	}
}
