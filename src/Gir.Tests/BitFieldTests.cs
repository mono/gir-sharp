
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class BitFieldTests : GenerationTestBase
	{
		[Test]
		public void GenerateDocumentationWhenCompatFalse ()
		{
			var result = GenerateType (Pango, "FontMask");
			Assert.AreEqual (@"namespace Pango
{
	///<summary>
	/// The bits in a #PangoFontMask correspond to fields in a
	/// #PangoFontDescription that have been set.
	///</summary>
	[Flags]
	public enum FontMask
	{
		///<summary>the font family is specified.</summary>
		Family = 0x1,

		///<summary>the font style is specified.</summary>
		Style = 0x2,

		///<summary>the font variant is specified.</summary>
		Variant = 0x4,

		///<summary>the font weight is specified.</summary>
		Weight = 0x8,

		///<summary>the font stretch is specified.</summary>
		Stretch = 0x10,

		///<summary>the font size is specified.</summary>
		Size = 0x20,

		///<summary>the font gravity is specified (Since: 1.16.)</summary>
		Gravity = 0x40,
	}
}
", result);
		}

		[Test]
		public void GenerateNoDocumentationWhenCompatTrue ()
		{
			var result = GenerateType (Pango, "FontMask", compat: true);

			Assert.AreEqual (@"namespace Pango
{
	[Flags]
	public enum FontMask
	{
		Family = 0x1,
		Style = 0x2,
		Variant = 0x4,
		Weight = 0x8,
		Stretch = 0x10,
		Size = 0x20,
		Gravity = 0x40,
	}
}
", result);
		}
	}
}
