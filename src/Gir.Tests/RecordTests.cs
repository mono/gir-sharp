using System;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class RecordTests : GenerationTestBase
	{
		[Test]
		public void TestRecordIsGenerated()
		{
			// Test is incomplete, as record is not fully generated atm.
			var result = GenerateType(GLib, "Array");

			Assert.AreEqual(@"namespace GLib
{
	///<summary>Contains the public fields of a GArray.</summary>
	public struct Array
	{
		///<summary>
		/// a pointer to the element data. The data may be moved as
		///     elements are added to the #GArray.
		///</summary>
		utf8 data;
		///<summary>
		/// the number of elements in the #GArray not including the
		///     possible terminating zero element.
		///</summary>
		guint len;
	}
}
", result);
		}
	}
}
