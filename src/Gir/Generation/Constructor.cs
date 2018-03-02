
namespace Gir
{
	public partial class Constructor : INativeCallable, IDocumented
	{
		public string GetModifiers (IGeneratable parent, GenerationOptions opts)
		{
			if (parent is Class @class && @class.Abstract)
				return "protected";

			return "public";
		}

		public void Generate (IGeneratable parent, IndentWriter writer)
		{
			this.GenerateConstructor (parent, writer);
		}

		public bool NewlineAfterGeneration (GenerationOptions opts) => true;
		bool INativeCallable.IsInstanceCallable (IGeneratable parent, GenerationOptions opts) => false;
	}
}
