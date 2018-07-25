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

			Assert.AreEqual (@"using System;
using System.Runtime.InteropServices;

namespace Gtk
{
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	public delegate void TreeModelFilterModifyFunc (ITreeModel model, TreeIter iter, Value value, int column, IntPtr data)

	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate void TreeModelFilterModifyFuncNative (ITreeModel model, TreeIter iter, Value value, int column, IntPtr data)

	internal static class TreeModelFilterModifyFuncWrapper
	{
		public static void NativeCallback (ITreeModel model, TreeIter iter, Value value, int column, IntPtr data)
		{
		}
	}
}
", result);
		}
	}
}
