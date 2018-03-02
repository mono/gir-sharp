using System;
namespace Gir
{
	public partial class Callback : IGeneratable, IMethodLike
	{
		public void Generate (GenerationOptions opts)
		{
			using (var writer = this.GetWriter (opts))
			{
				writer.WriteLine ("namespace " + opts.Namespace.Name);
				writer.WriteLine ("{");
				using (writer.Indent ()) {
					// TODO: Validation if we have an userdata parameter we can use so we can write this code.
					// Otherwise, we need to generate code which uses a non-static callback.

					var returnType = GetReturnType (writer);
					var (typesAndNames, names) = this.BuildParameters (opts, true);
					
					// Public API delegate which uses managed types.
					writer.WriteLine ("[UnmanagedFunctionPointer (CallingConvention.Cdecl)]");
					writer.WriteLine ($"public delegate {returnType} {Name} ({typesAndNames})");
					writer.WriteLine ();

					// Internal API delegate which uses unmanaged types.
					writer.WriteLine ("[UnmanagedFunctionPointer (CallingConvention.Cdecl)]");
					// TODO: Use native marshal types.
					writer.WriteLine ($"internal delegate {returnType} {Name}Native ({typesAndNames})");
					writer.WriteLine ();

					// Generate wrapper class - static if we can use gchandle, otherwise instance
					// Check callback convention - async, notify, call
				}
				writer.WriteLine ("}");
			}
		}

		string GetReturnType (IndentWriter writer)
		{
			// Write the managed delegate signature.
			var retVal = ReturnValue;
			if (retVal == null)
				return "void";

			// TODO: Handle marshalling.

			// Try getting the array return value, then the type one.
			var retSymbol = retVal.Resolve (writer.Options);
			return retSymbol.CSharpType;
		}
	}
}
