
namespace Gir
{
	public partial class Function : ICallable
	{
		public string Modifiers => "static";

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			this.GenerateCallableDefinition (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		public bool IsInstanceCallable => false;
	}
}
