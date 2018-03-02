
namespace Gir
{
	public partial class Constructor : ICallable, IDocumented
	{
		public string GetModifiers (IGeneratable parent)
		{
			if (parent is Class @class && @class.Abstract)
				return "protected";

			return "public";
		}

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
