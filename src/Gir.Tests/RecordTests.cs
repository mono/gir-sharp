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
			var result = GenerateType(GLib, "ByteArray");


			// Need to map pointers at symbol level.
			Console.WriteLine(result);
			Assert.AreEqual(@"namespace GLib
{
	///<summary>Contains the public fields of a GByteArray.</summary>
	public struct ByteArray
	{
		///<summary>
		/// a pointer to the element data. The data may be moved as
		///     elements are added to the #GByteArray
		///</summary>
		byte data;

		///<summary>the number of elements in the #GByteArray</summary>
		uint len;
	}
}
", result);
		}
	}
}
