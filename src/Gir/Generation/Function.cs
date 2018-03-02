
namespace Gir
{
	public partial class Function : ICallable
	{
		// TODO: Decide what to do here if we have functions which work
		// on instances (instance-parameter is not set)
		public string GetModifiers (IGeneratable parent) => "public static";

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		public bool IsInstanceCallable => false;
	}
}
