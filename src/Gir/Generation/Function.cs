using System.Linq;

namespace Gir
{
	public partial class Function : ICallable
	{
		// TODO: Decide what to do here if we have functions which work
		// on instances (instance-parameter is not set)
		public string GetModifiers (IGeneratable parent, GenerationOptions opts)
		{
			if (CanFirstParameterBeInstance (parent, opts))
				return "public";
			return "public static";
		}

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;

		public bool IsInstanceCallable (IGeneratable parent, GenerationOptions opts) => CanFirstParameterBeInstance (parent, opts);

		// TODO: Unexpose this
		public bool CanFirstParameterBeInstance (IGeneratable parent, GenerationOptions opts)
		{
			var param = Parameters.FirstOrDefault();
			if (param == null)
				return false;

			// hacky check for symbol equality
			return param.Resolve (opts).GetType () == parent.GetType ();
		}
	}
}
