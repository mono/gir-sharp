
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class FunctionTests : GenerationTestBase
	{
		[Test]
		public void TestRecordFunctionIsGenerated ()
		{
			// Test is incomplete, as record is not fully generated atm.
			var result = GenerateMember (GLib, "ByteArray", "append");

			Assert.AreEqual (@"static extern ByteArray g_byte_array_append (ByteArray array, byte data, uint len);

///<summary>
/// Adds the given bytes to the end of the #GByteArray.
/// The array will grow in size automatically if necessary.
///</summary>
///<returns>the #GByteArray</returns>
public ByteArray Append (byte data, uint len)
{
	return g_byte_array_append (data, len);
}
", result);
		}
	}
}
