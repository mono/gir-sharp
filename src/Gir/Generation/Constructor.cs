
namespace Gir
{
	public partial class Constructor : ICallable, IDocumented
	{
		public string Modifiers => string.Empty;

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			this.GenerateConstructor (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts)
		{
			return true;
		}

		public bool IsInstanceCallable => false;
	}
}
