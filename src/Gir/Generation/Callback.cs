using System;
namespace Gir
{
	public partial class Callback : IGeneratable, IMethodLike
	{
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts))
			{
				// TODO: Validation if we have an userdata parameter we can use so we can write this code.
				// Otherwise, we need to generate code which uses a non-static callback.

				var returnType = this.GetReturnCSharpType (writer);
				var parameters = this.BuildParameters (opts, true);
					
				// Public API delegate which uses managed types.
				writer.WriteLine ("[UnmanagedFunctionPointer (CallingConvention.Cdecl)]");
				writer.WriteLine ($"public delegate {returnType} {Name} ({parameters.TypesAndNames})");
				writer.WriteLine ();

				// Internal API delegate which uses unmanaged types.
				writer.WriteLine ("[UnmanagedFunctionPointer (CallingConvention.Cdecl)]");
				// TODO: Use native marshal types.
				writer.WriteLine ($"internal delegate {returnType} {Name}Native ({parameters.TypesAndNames})");
				writer.WriteLine ();

				// Generate wrapper class - static if we can use gchandle, otherwise instance
				// Check callback convention - async, notify, call
				writer.WriteLine ($"internal static class {Name}Wrapper");
				writer.WriteLine ("{");
				using (writer.Indent ()) {
					writer.WriteLine ($"public static void NativeCallback ({parameters.TypesAndNames})");
					writer.WriteLine ("{");
					// TODO: marshal params, call, handle exceptions
					writer.WriteLine ("}");
				}
				writer.WriteLine ("}");
			}
		}
	}
}
