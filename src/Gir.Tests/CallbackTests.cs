using System;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class CallbackTests : GenerationTestBase
	{
		[Test]
		public void TestCallbackIsGenerated ()
		{
			var result = GenerateType (Gtk3, "TreeModelFilterModifyFunc");

			Console.WriteLine (result);
			Assert.AreEqual (@"namespace Gtk
{
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	public delegate void TreeModelFilterModifyFunc PARAMS

	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate void TreeModelFilterModifyFuncNative PARAMS

}
", result);
		}
	}
}
